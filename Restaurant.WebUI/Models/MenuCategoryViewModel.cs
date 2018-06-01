using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Models
{
    public class MenuCategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Position")]
        [Range(1, 50)]
        public int Position { get; set; }
    }
}