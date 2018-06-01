using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete.Repository
{
    public class EFReservationRepository : EFRepository<Reservation>, IEFReservationRepository
    {
        public EFReservationRepository(EFRestaurantDbContext context) : base(context)
        {
        }

        public IList<Reservation> GetByTerm(DateTime beginDateTime, DateTime lastDateTime)
        {
            var result = _dbSet.Where(w => w.Term >= beginDateTime && w.Term <= lastDateTime).ToList();
            return result;
        }
    }
}
