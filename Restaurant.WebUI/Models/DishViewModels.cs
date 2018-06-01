using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Models
{
    public class CreateDishViewModel
    {
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [Range(0.00, 10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Position { get; set; }
        public SelectList Positions { get; set; }

        [Required]
        [Display(Name = "Menu category")]
        public string MenuCategoryName { get; set; }
        public SelectList MenuCategories { get; set; }
    }

    public class EditDishViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int DishID { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [Range(0.00, 10000)]
        public decimal Price { get; set; }

        [HiddenInput(DisplayValue = false)]
        public byte[] Photo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string PhotoMimeType { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Position { get; set; }
        public SelectList Positions { get; set; }

        [Required]
        [Display(Name = "Menu category")]
        public string MenuCategoryName { get; set; }
        public SelectList MenuCategories { get; set; }
    }
}