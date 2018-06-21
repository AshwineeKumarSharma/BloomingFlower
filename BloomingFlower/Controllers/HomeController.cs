using BloomingFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloomingFlower.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult NewsAndEvents()
        {
            MyDbContext db = new MyDbContext();
            return View(db.NewsAndEventsInfoes.ToList());
        }

        public ActionResult Admissions()
        {
            return View();
        }

        public ActionResult Academics()
        {
            return View(db.AcademicActivitiesImagesInfoes.ToList());
        }

        public ActionResult Activities()
        {
            return View(db.ExtraActivitiesImagesInfoes.ToList());
        }
    }
}