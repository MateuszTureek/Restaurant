using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.WebUI.Models
{
    public class RoleViewModel
    {
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }

    public class RoleListViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Role name")]
        public string RoleName { get; set; }

        [Display(Name = "Added date")]
        public DateTime AddedDate { get; set; }
    }
}