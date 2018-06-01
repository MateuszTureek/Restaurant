using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }
    }
}
