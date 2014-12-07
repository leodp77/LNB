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
    public class PlayerTeamRelationshipController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /PlayerTeamRelationship/
        public ActionResult Index()
        {
            var playerteamrelationships = db.PlayerTeamRelationships.Include(p => p.Player).Include(p => p.Team);
            return View(playerteamrelationships.ToList());
        }

        // GET: /PlayerTeamRelationship/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTeamRelationship playerteamrelationship = db.PlayerTeamRelationships.Find(id);
            if (playerteamrelationship == null)
            {
                return HttpNotFound();
            }
            return View(playerteamrelationship);
        }

        // GET: /PlayerTeamRelationship/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        // POST: /PlayerTeamRelationship/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerTeamRelationshipId,PlayerId,TeamId,Number,StartDate,EndDate")] PlayerTeamRelationship playerteamrelationship)
        {
            if (ModelState.IsValid)
            {
                db.PlayerTeamRelationships.Add(playerteamrelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerteamrelationship.PlayerId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", playerteamrelationship.TeamId);
            return View(playerteamrelationship);
        }

        // GET: /PlayerTeamRelationship/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTeamRelationship playerteamrelationship = db.PlayerTeamRelationships.Find(id);
            if (playerteamrelationship == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerteamrelationship.PlayerId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", playerteamrelationship.TeamId);
            return View(playerteamrelationship);
        }

        // POST: /PlayerTeamRelationship/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerTeamRelationshipId,PlayerId,TeamId,Number,StartDate,EndDate")] PlayerTeamRelationship playerteamrelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerteamrelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerteamrelationship.PlayerId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", playerteamrelationship.TeamId);
            return View(playerteamrelationship);
        }

        // GET: /PlayerTeamRelationship/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTeamRelationship playerteamrelationship = db.PlayerTeamRelationships.Find(id);
            if (playerteamrelationship == null)
            {
                return HttpNotFound();
            }
            return View(playerteamrelationship);
        }

        // POST: /PlayerTeamRelationship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerTeamRelationship playerteamrelationship = db.PlayerTeamRelationships.Find(id);
            db.PlayerTeamRelationships.Remove(playerteamrelationship);
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
