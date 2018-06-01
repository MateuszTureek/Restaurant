using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoMimeType { get; set; }
        public byte[] Photo { get; set; }

        public int MenuCatId { get; set; }
        public virtual MenuCategory MenuCategory { get; set; }
    }
}
