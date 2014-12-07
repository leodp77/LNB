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
    public class TeamPlayTypeController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /TeamPlayType/
        public ActionResult Index()
        {
            return View(db.TeamPlayType.ToList());
        }

        // GET: /TeamPlayType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlayType teamplaytype = db.TeamPlayType.Find(id);
            if (teamplaytype == null)
            {
                return HttpNotFound();
            }
            return View(teamplaytype);
        }

        // GET: /TeamPlayType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TeamPlayType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeamPlayTypeId,Description")] TeamPlayType teamplaytype)
        {
            if (ModelState.IsValid)
            {
                db.TeamPlayType.Add(teamplaytype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamplaytype);
        }

        // GET: /TeamPlayType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlayType teamplaytype = db.TeamPlayType.Find(id);
            if (teamplaytype == null)
            {
                return HttpNotFound();
            }
            return View(teamplaytype);
        }

        // POST: /TeamPlayType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TeamPlayTypeId,Description")] TeamPlayType teamplaytype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamplaytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamplaytype);
        }

        // GET: /TeamPlayType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlayType teamplaytype = db.TeamPlayType.Find(id);
            if (teamplaytype == null)
            {
                return HttpNotFound();
            }
            return View(teamplaytype);
        }

        // POST: /TeamPlayType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamPlayType teamplaytype = db.TeamPlayType.Find(id);
            db.TeamPlayType.Remove(teamplaytype);
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
