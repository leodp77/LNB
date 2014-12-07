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
    public class PlayerStatisticController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /PlayerStatistic/
        public ActionResult Index()
        {
            var playerstatistics = db.PlayerStatistics.Include(p => p.Game).Include(p => p.Player);
            return View(playerstatistics.ToList());
        }

        // GET: /PlayerStatistic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerStatistic playerstatistic = db.PlayerStatistics.Find(id);
            if (playerstatistic == null)
            {
                return HttpNotFound();
            }
            return View(playerstatistic);
        }

        // GET: /PlayerStatistic/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName");
            return View();
        }

        // POST: /PlayerStatistic/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerStatisticId,PlayerId,Minutes,Points,TwoPointsMade,TwoPointsAttempt,ThreePointsMade,ThreePointsAttempt,SinglePointsMade,SinglePointsAttempt,OffensiveRebounds,DefensiveRebounds,Assists,Steals,Blocks,Turnovers,PersonalFouls,TechnicalFouls,FlagrantFouls,HasStarted,GameId")] PlayerStatistic playerstatistic)
        {
            if (ModelState.IsValid)
            {
                db.PlayerStatistics.Add(playerstatistic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", playerstatistic.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerstatistic.PlayerId);
            return View(playerstatistic);
        }

        // GET: /PlayerStatistic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerStatistic playerstatistic = db.PlayerStatistics.Find(id);
            if (playerstatistic == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", playerstatistic.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerstatistic.PlayerId);
            return View(playerstatistic);
        }

        // POST: /PlayerStatistic/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerStatisticId,PlayerId,Minutes,Points,TwoPointsMade,TwoPointsAttempt,ThreePointsMade,ThreePointsAttempt,SinglePointsMade,SinglePointsAttempt,OffensiveRebounds,DefensiveRebounds,Assists,Steals,Blocks,Turnovers,PersonalFouls,TechnicalFouls,FlagrantFouls,HasStarted,GameId")] PlayerStatistic playerstatistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerstatistic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", playerstatistic.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerstatistic.PlayerId);
            return View(playerstatistic);
        }

        // GET: /PlayerStatistic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerStatistic playerstatistic = db.PlayerStatistics.Find(id);
            if (playerstatistic == null)
            {
                return HttpNotFound();
            }
            return View(playerstatistic);
        }

        // POST: /PlayerStatistic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerStatistic playerstatistic = db.PlayerStatistics.Find(id);
            db.PlayerStatistics.Remove(playerstatistic);
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
