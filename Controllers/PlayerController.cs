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
    public class PlayerController : Controller
    {
        private LnbContext db = new LnbContext();

        // GET: /Player/
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SurnameSortParm = String.IsNullOrEmpty(sortOrder) ? "surname_desc" : "";
            ViewBag.HeightSortParm = sortOrder=="Height" ? "height_desc" : "Height";

            var players = db.Players.Include(p => p.Country).Include(p => p.PlayerPrincipalPosition).Include(p => p.PlayerSecondaryPosition);

            if(!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(p=>p.Surname.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "surname_desc":
                    players = players.OrderByDescending(p => p.Surname);
                    break;
                case "Height":
                    players = players.OrderBy(p => p.Height);
                    break;
                case "height_desc":
                    players = players.OrderByDescending(p => p.Height);
                    break;
                default:
                    players = players.OrderBy(p => p.Surname);
                    break;
            }

            return View(players.ToList());
        }

        // GET: /Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: /Player/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.PlayerPrincipalPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation");
            ViewBag.PlayerSecondaryPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation");
            return View();
        }

        // POST: /Player/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayerId,Weight,Height,NickName,PlayerPrincipalPositionId,PlayerSecondaryPositionId,Name,Surname,DocumentNumber,BirthDate,IsActive,CountryId,Province,City")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            ViewBag.PlayerPrincipalPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation", player.PlayerPrincipalPositionId);
            ViewBag.PlayerSecondaryPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation", player.PlayerSecondaryPositionId);
            return View(player);
        }

        // GET: /Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            ViewBag.PlayerPrincipalPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation", player.PlayerPrincipalPositionId);
            ViewBag.PlayerSecondaryPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation", player.PlayerSecondaryPositionId);
            return View(player);
        }

        // POST: /Player/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerId,Weight,Height,NickName,PlayerPrincipalPositionId,PlayerSecondaryPositionId,Name,Surname,DocumentNumber,BirthDate,IsActive,CountryId,Province,City")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            ViewBag.PlayerPrincipalPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation", player.PlayerPrincipalPositionId);
            ViewBag.PlayerSecondaryPositionId = new SelectList(db.PlayerPositions, "PlayerPositionId", "Abbreviation", player.PlayerSecondaryPositionId);
            return View(player);
        }

        // GET: /Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: /Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
