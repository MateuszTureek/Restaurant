using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name,DateTime addedDate) : base(name)
        {
            this.AddedDate = addedDate;
        }

        public virtual DateTime AddedDate{ get; set; }
    }
}
