using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNB.DAL;

namespace LNB.Controllers
{
    public class HomeController : Controller
    {
        LnbContext db = new LnbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aquí encontrarás toda la información de la Liga Nacional de Basquetbol argentino.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactate con nosotros.";

            return View();
        }
    }
}