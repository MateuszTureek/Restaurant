using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete.Repository
{
    public class EFGalleryRepository : EFRepository<Gallery>, IEFGalleryRepository
    {
        public EFGalleryRepository(EFRestaurantDbContext context) : base(context)
        {
        }

        public IList<Gallery> GetGalleryByPosition()
        {
            var result = _dbSet.OrderBy(o => o.Position).ToList();
            return result;
        }
    }
}
