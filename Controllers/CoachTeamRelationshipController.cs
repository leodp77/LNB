using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LNB.Models;
using LNB.DAL;

namespace LNB.Controllers
{
    public class CoachTeamRelationshipController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /CoachTeamRelationship/
        public ActionResult Index()
        {
            var coachteamrelationships = db.CoachTeamRelationships.Include(c => c.Coach).Include(c => c.Team);
            return View(coachteamrelationships.ToList());
        }

        // GET: /CoachTeamRelationship/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachTeamRelationship coachteamrelationship = db.CoachTeamRelationships.Find(id);
            if (coachteamrelationship == null)
            {
                return HttpNotFound();
            }
            return View(coachteamrelationship);
        }

        // GET: /CoachTeamRelationship/Create
        public ActionResult Create()
        {
            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        // POST: /CoachTeamRelationship/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CoachTeamRelationshipId,CoachId,TeamId,StartDate,EndDate")] CoachTeamRelationship coachteamrelationship)
        {
            if (ModelState.IsValid)
            {
                db.CoachTeamRelationships.Add(coachteamrelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name", coachteamrelationship.CoachId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", coachteamrelationship.TeamId);
            return View(coachteamrelationship);
        }

        // GET: /CoachTeamRelationship/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachTeamRelationship coachteamrelationship = db.CoachTeamRelationships.Find(id);
            if (coachteamrelationship == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name", coachteamrelationship.CoachId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", coachteamrelationship.TeamId);
            return View(coachteamrelationship);
        }

        // POST: /CoachTeamRelationship/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CoachTeamRelationshipId,CoachId,TeamId,StartDate,EndDate")] CoachTeamRelationship coachteamrelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coachteamrelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name", coachteamrelationship.CoachId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", coachteamrelationship.TeamId);
            return View(coachteamrelationship);
        }

        // GET: /CoachTeamRelationship/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachTeamRelationship coachteamrelationship = db.CoachTeamRelationships.Find(id);
            if (coachteamrelationship == null)
            {
                return HttpNotFound();
            }
            return View(coachteamrelationship);
        }

        // POST: /CoachTeamRelationship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoachTeamRelationship coachteamrelationship = db.CoachTeamRelationships.Find(id);
            db.CoachTeamRelationships.Remove(coachteamrelationship);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
