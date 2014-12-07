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
    public class PlayerPlayTypeController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /PlayerPlayType/
        public ActionResult Index()
        {
            return View(db.PlayerPlayTypes.ToList());
        }

        // GET: /PlayerPlayType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPlayType playerplaytype = db.PlayerPlayTypes.Find(id);
            if (playerplaytype == null)
            {
                return HttpNotFound();
            }
            return View(playerplaytype);
        }

        // GET: /PlayerPlayType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlayerPlayType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerPlayTypeId,Description")] PlayerPlayType playerplaytype)
        {
            if (ModelState.IsValid)
            {
                db.PlayerPlayTypes.Add(playerplaytype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerplaytype);
        }

        // GET: /PlayerPlayType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPlayType playerplaytype = db.PlayerPlayTypes.Find(id);
            if (playerplaytype == null)
            {
                return HttpNotFound();
            }
            return View(playerplaytype);
        }

        // POST: /PlayerPlayType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerPlayTypeId,Description")] PlayerPlayType playerplaytype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerplaytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerplaytype);
        }

        // GET: /PlayerPlayType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPlayType playerplaytype = db.PlayerPlayTypes.Find(id);
            if (playerplaytype == null)
            {
                return HttpNotFound();
            }
            return View(playerplaytype);
        }

        // POST: /PlayerPlayType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerPlayType playerplaytype = db.PlayerPlayTypes.Find(id);
            db.PlayerPlayTypes.Remove(playerplaytype);
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
