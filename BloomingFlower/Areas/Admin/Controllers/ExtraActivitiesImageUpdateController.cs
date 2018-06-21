using BloomingFlower.Areas.Admin.Models;
using BloomingFlower.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloomingFlower.Areas.Admin.Controllers
{
    public class ExtraActivitiesImageUpdateController : Controller
    {
        // GET: Admin/ExtraActivitiesImageUpdate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Image,ExtraActivitiesImageUpdateViewModel el)
        {

            MyDbContext db = new MyDbContext();
            ExtraActivitiesImagesInfo AAI = new ExtraActivitiesImagesInfo();
            if (el.Image == null || el.Image.ContentLength == 0)
            {
                ModelState.AddModelError("Image", "The image file is required.");
            }
            else
            {
                var extensions = new string[] { 
                 "image/gif",
                 "image/jpeg",
                 "image/png",
                 "image/jpg"
                };
                if (!extensions.Contains(el.Image.ContentType))
                {
                    ModelState.AddModelError("Image", "Please choose image file (Jpg,jpeg,png,gif)");
                }
            }
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(el.Image.FileName);
                //Save image file to web server not in the db
                string path = Path.Combine(Server.MapPath("~/Extras/ExtraActivitiesImages"), fileName);
                el.Image.SaveAs(path);

                //now save file name to db along with image title and other attributes
                AAI.ID = el.Id;
                AAI.Title = el.Title;
                AAI.ImageUrl = fileName;
                AAI.AltText = el.AltText;
                AAI.Description = el.Description;
                db.ExtraActivitiesImagesInfoes.Add(AAI);
                db.SaveChanges();


            }

            return View();
        }
    }
}