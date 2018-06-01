using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Abstract.Repository
{
    public interface IEFReservationRepository : IEFRepository<Reservation>
    {
        IList<Reservation> GetByTerm(DateTime beginDateTime, DateTime lastDateTime);
    }
}
