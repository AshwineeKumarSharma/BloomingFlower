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
    public class AcademicActivitiesImagesInfoesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/AcademicActivitiesImagesInfoes
        public ActionResult Index()
        {
            return View(db.AcademicActivitiesImagesInfoes.ToList());
        }

        // GET: Admin/AcademicActivitiesImagesInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicActivitiesImagesInfo academicActivitiesImagesInfo = db.AcademicActivitiesImagesInfoes.Find(id);
            if (academicActivitiesImagesInfo == null)
            {
                return HttpNotFound();
            }
            return View(academicActivitiesImagesInfo);
        }

        // GET: Admin/AcademicActivitiesImagesInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AcademicActivitiesImagesInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImageUrl,AltText,Title,Description")] AcademicActivitiesImagesInfo academicActivitiesImagesInfo)
        {
            if (ModelState.IsValid)
            {
                db.AcademicActivitiesImagesInfoes.Add(academicActivitiesImagesInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicActivitiesImagesInfo);
        }

        // GET: Admin/AcademicActivitiesImagesInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicActivitiesImagesInfo academicActivitiesImagesInfo = db.AcademicActivitiesImagesInfoes.Find(id);
            if (academicActivitiesImagesInfo == null)
            {
                return HttpNotFound();
            }
            return View(academicActivitiesImagesInfo);
        }

        // POST: Admin/AcademicActivitiesImagesInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImageUrl,AltText,Title,Description")] AcademicActivitiesImagesInfo academicActivitiesImagesInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicActivitiesImagesInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicActivitiesImagesInfo);
        }

        // GET: Admin/AcademicActivitiesImagesInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicActivitiesImagesInfo academicActivitiesImagesInfo = db.AcademicActivitiesImagesInfoes.Find(id);
            if (academicActivitiesImagesInfo == null)
            {
                return HttpNotFound();
            }
            return View(academicActivitiesImagesInfo);
        }

        // POST: Admin/AcademicActivitiesImagesInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicActivitiesImagesInfo academicActivitiesImagesInfo = db.AcademicActivitiesImagesInfoes.Find(id);
            db.AcademicActivitiesImagesInfoes.Remove(academicActivitiesImagesInfo);
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
