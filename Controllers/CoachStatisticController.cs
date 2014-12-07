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
    public class CoachStatisticController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /CoachStatistic/
        public ActionResult Index()
        {
            var coachstatistics = db.CoachStatistics.Include(c => c.Coach).Include(c => c.Game);
            return View(coachstatistics.ToList());
        }

        // GET: /CoachStatistic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachStatistic coachstatistic = db.CoachStatistics.Find(id);
            if (coachstatistic == null)
            {
                return HttpNotFound();
            }
            return View(coachstatistic);
        }

        // GET: /CoachStatistic/Create
        public ActionResult Create()
        {
            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name");
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId");
            return View();
        }

        // POST: /CoachStatistic/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CoachStatisticId,CoachId,TechnicalFouls,GameId")] CoachStatistic coachstatistic)
        {
            if (ModelState.IsValid)
            {
                db.CoachStatistics.Add(coachstatistic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name", coachstatistic.CoachId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", coachstatistic.GameId);
            return View(coachstatistic);
        }

        // GET: /CoachStatistic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachStatistic coachstatistic = db.CoachStatistics.Find(id);
            if (coachstatistic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name", coachstatistic.CoachId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", coachstatistic.GameId);
            return View(coachstatistic);
        }

        // POST: /CoachStatistic/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CoachStatisticId,CoachId,TechnicalFouls,GameId")] CoachStatistic coachstatistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coachstatistic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachId = new SelectList(db.Coaches, "CoachId", "Name", coachstatistic.CoachId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", coachstatistic.GameId);
            return View(coachstatistic);
        }

        // GET: /CoachStatistic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachStatistic coachstatistic = db.CoachStatistics.Find(id);
            if (coachstatistic == null)
            {
                return HttpNotFound();
            }
            return View(coachstatistic);
        }

        // POST: /CoachStatistic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoachStatistic coachstatistic = db.CoachStatistics.Find(id);
            db.CoachStatistics.Remove(coachstatistic);
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
