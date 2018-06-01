using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.WebUI.Models
{
    public class UserListViewModel
    {
        public string UserID { get; set; }

        [Display(Name="User name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Account create date")]
        public DateTime AddedDate { get; set; }

        [Display(Name = "Phone number")]
        public string PhonNumber { get; set; }
    }
}