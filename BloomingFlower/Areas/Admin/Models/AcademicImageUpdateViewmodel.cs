using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloomingFlower.Areas.Admin.Models
{
    public class AcademicImageUpdateViewmodel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Image file is required.")]
        public HttpPostedFileBase Image { get; set; }

        [Required(ErrorMessage = "Image title is required.")]
        public string Title { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }
    }
}