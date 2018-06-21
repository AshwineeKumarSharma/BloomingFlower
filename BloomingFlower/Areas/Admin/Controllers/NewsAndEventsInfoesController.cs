using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloomingFlower.Models;

namespace BloomingFlower.Areas.Admin.Controllers
{
    public class NewsAndEventsInfoesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/NewsAndEventsInfoes
        public ActionResult Index()
        {
            return View(db.NewsAndEventsInfoes.ToList());
        }

        // GET: Admin/NewsAndEventsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsAndEventsInfo newsAndEventsInfo = db.NewsAndEventsInfoes.Find(id);
            if (newsAndEventsInfo == null)
            {
                return HttpNotFound();
            }
            return View(newsAndEventsInfo);
        }

        // GET: Admin/NewsAndEventsInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsAndEventsInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] NewsAndEventsInfo newsAndEventsInfo)
        {
            if (ModelState.IsValid)
            {
                db.NewsAndEventsInfoes.Add(newsAndEventsInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsAndEventsInfo);
        }

        // GET: Admin/NewsAndEventsInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsAndEventsInfo newsAndEventsInfo = db.NewsAndEventsInfoes.Find(id);
            if (newsAndEventsInfo == null)
            {
                return HttpNotFound();
            }
            return View(newsAndEventsInfo);
        }

        // POST: Admin/NewsAndEventsInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] NewsAndEventsInfo newsAndEventsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsAndEventsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsAndEventsInfo);
        }

        // GET: Admin/NewsAndEventsInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsAndEventsInfo newsAndEventsInfo = db.NewsAndEventsInfoes.Find(id);
            if (newsAndEventsInfo == null)
            {
                return HttpNotFound();
            }
            return View(newsAndEventsInfo);
        }

        // POST: Admin/NewsAndEventsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsAndEventsInfo newsAndEventsInfo = db.NewsAndEventsInfoes.Find(id);
            db.NewsAndEventsInfoes.Remove(newsAndEventsInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NewsAndEventsUpdate()
        {
            return View(db.NewsAndEventsInfoes.ToList());
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
