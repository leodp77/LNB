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
using System.Globalization;

namespace LNB.Controllers
{
    public class TeamStatisticController : Controller
    {
        private LnbContext db = new LnbContext();
        
        // GET: /TeamStatistic/
        public ActionResult Index()
        {
            var teamstatistics = db.TeamStatistics.Include(t => t.Game).Include(t => t.Team);
            return View(teamstatistics.ToList());
        }

        // GET: /TeamStatistic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamStatistic teamstatistic = db.TeamStatistics.Find(id);
            if (teamstatistic == null)
            {
                return HttpNotFound();
            }
            return View(teamstatistic);
        }

        // GET: /TeamStatistic/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        // POST: /TeamStatistic/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeamStatisticId,TeamId,GameId")] TeamStatistic teamstatistic)
        {
            if (ModelState.IsValid)
            {
                db.TeamStatistics.Add(teamstatistic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", teamstatistic.GameId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", teamstatistic.TeamId);
            return View(teamstatistic);
        }

        // GET: /TeamStatistic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamStatistic teamstatistic = db.TeamStatistics.Find(id);
            if (teamstatistic == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", teamstatistic.GameId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", teamstatistic.TeamId);
            return View(teamstatistic);
        }

        // POST: /TeamStatistic/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TeamStatisticId,TeamId,GameId")] TeamStatistic teamstatistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamstatistic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", teamstatistic.GameId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", teamstatistic.TeamId);
            return View(teamstatistic);
        }

        // GET: /TeamStatistic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamStatistic teamstatistic = db.TeamStatistics.Find(id);
            if (teamstatistic == null)
            {
                return HttpNotFound();
            }
            return View(teamstatistic);
        }

        // POST: /TeamStatistic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamStatistic teamstatistic = db.TeamStatistics.Find(id);
            db.TeamStatistics.Remove(teamstatistic);
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
