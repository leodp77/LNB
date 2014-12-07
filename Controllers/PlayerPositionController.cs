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
    public class PlayerPositionController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /PlayerPosition/
        public ActionResult Index()
        {
            return View(db.PlayerPositions.ToList());
        }

        // GET: /PlayerPosition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPosition playerposition = db.PlayerPositions.Find(id);
            if (playerposition == null)
            {
                return HttpNotFound();
            }
            return View(playerposition);
        }

        // GET: /PlayerPosition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlayerPosition/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerPositionId,Abbreviation,Name")] PlayerPosition playerposition)
        {
            if (ModelState.IsValid)
            {
                db.PlayerPositions.Add(playerposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerposition);
        }

        // GET: /PlayerPosition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPosition playerposition = db.PlayerPositions.Find(id);
            if (playerposition == null)
            {
                return HttpNotFound();
            }
            return View(playerposition);
        }

        // POST: /PlayerPosition/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerPositionId,Abbreviation,Name")] PlayerPosition playerposition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerposition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerposition);
        }

        // GET: /PlayerPosition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPosition playerposition = db.PlayerPositions.Find(id);
            if (playerposition == null)
            {
                return HttpNotFound();
            }
            return View(playerposition);
        }

        // POST: /PlayerPosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerPosition playerposition = db.PlayerPositions.Find(id);
            db.PlayerPositions.Remove(playerposition);
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
