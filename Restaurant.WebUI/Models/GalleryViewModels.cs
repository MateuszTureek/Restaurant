using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Models
{
    public class CreateGalleryItemViewModel
    {
        [Range(1, 50)]
        public int Position { get; set; }
    }

    public class EditGalleryItemViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public byte[] Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [Range(1, 50)]
        public int Position { get; set; }
    }
}