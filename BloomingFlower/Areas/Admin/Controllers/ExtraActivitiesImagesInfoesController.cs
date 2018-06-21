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
    public class ExtraActivitiesImagesInfoesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/ExtraActivitiesImagesInfoes
        public ActionResult Index()
        {
            return View(db.ExtraActivitiesImagesInfoes.ToList());
        }

        // GET: Admin/ExtraActivitiesImagesInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivitiesImagesInfo extraActivitiesImagesInfo = db.ExtraActivitiesImagesInfoes.Find(id);
            if (extraActivitiesImagesInfo == null)
            {
                return HttpNotFound();
            }
            return View(extraActivitiesImagesInfo);
        }

        // GET: Admin/ExtraActivitiesImagesInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ExtraActivitiesImagesInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImageUrl,AltText,Title,Description")] ExtraActivitiesImagesInfo extraActivitiesImagesInfo)
        {
            if (ModelState.IsValid)
            {
                db.ExtraActivitiesImagesInfoes.Add(extraActivitiesImagesInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extraActivitiesImagesInfo);
        }

        // GET: Admin/ExtraActivitiesImagesInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivitiesImagesInfo extraActivitiesImagesInfo = db.ExtraActivitiesImagesInfoes.Find(id);
            if (extraActivitiesImagesInfo == null)
            {
                return HttpNotFound();
            }
            return View(extraActivitiesImagesInfo);
        }

        // POST: Admin/ExtraActivitiesImagesInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImageUrl,AltText,Title,Description")] ExtraActivitiesImagesInfo extraActivitiesImagesInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraActivitiesImagesInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extraActivitiesImagesInfo);
        }

        // GET: Admin/ExtraActivitiesImagesInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivitiesImagesInfo extraActivitiesImagesInfo = db.ExtraActivitiesImagesInfoes.Find(id);
            if (extraActivitiesImagesInfo == null)
            {
                return HttpNotFound();
            }
            return View(extraActivitiesImagesInfo);
        }

        // POST: Admin/ExtraActivitiesImagesInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtraActivitiesImagesInfo extraActivitiesImagesInfo = db.ExtraActivitiesImagesInfoes.Find(id);
            db.ExtraActivitiesImagesInfoes.Remove(extraActivitiesImagesInfo);
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
