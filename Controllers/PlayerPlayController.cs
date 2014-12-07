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
    public class PlayerPlayController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /PlayerPlay/
        public ActionResult Index()
        {
            var playerplays = db.PlayerPlays.Include(p => p.Game).Include(p => p.Player).Include(p => p.PlayerPlayType);
            return View(playerplays.ToList());
        }

        // GET: /PlayerPlay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPlay playerplay = db.PlayerPlays.Find(id);
            if (playerplay == null)
            {
                return HttpNotFound();
            }
            return View(playerplay);
        }

        // GET: /PlayerPlay/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName");
            ViewBag.PlayerPlayTypeId = new SelectList(db.PlayerPlayTypes, "PlayerPlayTypeId", "Description");
            return View();
        }

        // POST: /PlayerPlay/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerPlayId,PlayerId,PlayerPlayTypeId,GameId,Minutes,Seconds")] PlayerPlay playerplay)
        {
            if (ModelState.IsValid)
            {
                db.PlayerPlays.Add(playerplay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", playerplay.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerplay.PlayerId);
            ViewBag.PlayerPlayTypeId = new SelectList(db.PlayerPlayTypes, "PlayerPlayTypeId", "Description", playerplay.PlayerPlayTypeId);
            return View(playerplay);
        }

        // GET: /PlayerPlay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPlay playerplay = db.PlayerPlays.Find(id);
            if (playerplay == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", playerplay.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerplay.PlayerId);
            ViewBag.PlayerPlayTypeId = new SelectList(db.PlayerPlayTypes, "PlayerPlayTypeId", "Description", playerplay.PlayerPlayTypeId);
            return View(playerplay);
        }

        // POST: /PlayerPlay/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerPlayId,PlayerId,PlayerPlayTypeId,GameId,Minutes,Seconds")] PlayerPlay playerplay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerplay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", playerplay.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "NickName", playerplay.PlayerId);
            ViewBag.PlayerPlayTypeId = new SelectList(db.PlayerPlayTypes, "PlayerPlayTypeId", "Description", playerplay.PlayerPlayTypeId);
            return View(playerplay);
        }

        // GET: /PlayerPlay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPlay playerplay = db.PlayerPlays.Find(id);
            if (playerplay == null)
            {
                return HttpNotFound();
            }
            return View(playerplay);
        }

        // POST: /PlayerPlay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerPlay playerplay = db.PlayerPlays.Find(id);
            db.PlayerPlays.Remove(playerplay);
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
