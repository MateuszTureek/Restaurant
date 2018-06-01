using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
