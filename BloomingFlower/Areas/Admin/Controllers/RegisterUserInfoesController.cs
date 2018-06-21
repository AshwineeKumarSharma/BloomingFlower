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
    public class RegisterUserInfoesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/RegisterUserInfoes
        public ActionResult Index()
        {
            return View(db.RegisterUserInfoes.ToList());
        }

        // GET: Admin/RegisterUserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterUserInfo registerUserInfo = db.RegisterUserInfoes.Find(id);
            if (registerUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(registerUserInfo);
        }

        // GET: Admin/RegisterUserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RegisterUserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] RegisterUserInfo registerUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.RegisterUserInfoes.Add(registerUserInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerUserInfo);
        }

        // GET: Admin/RegisterUserInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterUserInfo registerUserInfo = db.RegisterUserInfoes.Find(id);
            if (registerUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(registerUserInfo);
        }

        // POST: Admin/RegisterUserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password")] RegisterUserInfo registerUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerUserInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerUserInfo);
        }

        // GET: Admin/RegisterUserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterUserInfo registerUserInfo = db.RegisterUserInfoes.Find(id);
            if (registerUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(registerUserInfo);
        }

        // POST: Admin/RegisterUserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterUserInfo registerUserInfo = db.RegisterUserInfoes.Find(id);
            db.RegisterUserInfoes.Remove(registerUserInfo);
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
