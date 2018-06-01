using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Term { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public short NumberOfGuests { get; set; }
        public bool Arrived { get; set; }
    }
}