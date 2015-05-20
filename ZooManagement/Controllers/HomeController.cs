using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZooManagement.Controllers
{
    public class HomeController : Controller
    {
        private DataStore DataStore = new DataStore();
        public ActionResult Animals()
        {
            return View();
        }

        public ActionResult AnimalsEdit()
        {
            return View();
        }

        public ActionResult Zookeepers()
        {
            return View();
        }

        public ActionResult ZookeepersEdit()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}