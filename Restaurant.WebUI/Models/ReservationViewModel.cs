using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Models
{
    public class ReservationViewModel
    {
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\sąćęłńóśźżĄĘŁŃÓŚŹŻ]+$")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-dd-mm}")]
        public DateTime Term { get; set; }
        
        [Required]
        [StringLength(30)]
        [Display(Name="Phone number")]
        [RegularExpression(@"^[0-9()-]+$")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name="Guests")]
        public short NumberOfGuests { get; set; }
    }
}