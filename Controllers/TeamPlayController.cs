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
    public class TeamPlayController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /TeamPlay/
        public ActionResult Index()
        {
            var teamplays = db.TeamPlays.Include(t => t.Game).Include(t => t.Team).Include(t => t.TeamPlayType);
            return View(teamplays.ToList());
        }

        // GET: /TeamPlay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlay teamplay = db.TeamPlays.Find(id);
            if (teamplay == null)
            {
                return HttpNotFound();
            }
            return View(teamplay);
        }

        // GET: /TeamPlay/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            ViewBag.TeamPlayTypeId = new SelectList(db.TeamPlayType, "TeamPlayTypeId", "Description");
            return View();
        }

        // POST: /TeamPlay/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeamPlayId,TeamId,TeamPlayTypeId,GameId,Minutes,Seconds")] TeamPlay teamplay)
        {
            if (ModelState.IsValid)
            {
                db.TeamPlays.Add(teamplay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", teamplay.GameId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", teamplay.TeamId);
            ViewBag.TeamPlayTypeId = new SelectList(db.TeamPlayType, "TeamPlayTypeId", "Description", teamplay.TeamPlayTypeId);
            return View(teamplay);
        }

        // GET: /TeamPlay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlay teamplay = db.TeamPlays.Find(id);
            if (teamplay == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", teamplay.GameId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", teamplay.TeamId);
            ViewBag.TeamPlayTypeId = new SelectList(db.TeamPlayType, "TeamPlayTypeId", "Description", teamplay.TeamPlayTypeId);
            return View(teamplay);
        }

        // POST: /TeamPlay/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TeamPlayId,TeamId,TeamPlayTypeId,GameId,Minutes,Seconds")] TeamPlay teamplay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamplay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", teamplay.GameId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", teamplay.TeamId);
            ViewBag.TeamPlayTypeId = new SelectList(db.TeamPlayType, "TeamPlayTypeId", "Description", teamplay.TeamPlayTypeId);
            return View(teamplay);
        }

        // GET: /TeamPlay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlay teamplay = db.TeamPlays.Find(id);
            if (teamplay == null)
            {
                return HttpNotFound();
            }
            return View(teamplay);
        }

        // POST: /TeamPlay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamPlay teamplay = db.TeamPlays.Find(id);
            db.TeamPlays.Remove(teamplay);
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
