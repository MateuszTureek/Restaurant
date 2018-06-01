using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete.Repository
{
    public class EFMenuCategoryRepository : EFRepository<MenuCategory>, IEFMenuCategoryRepository
    {
        public EFMenuCategoryRepository(EFRestaurantDbContext context) : base(context)
        {
        }

        public MenuCategory GetByName(string name)
        {
            var result = _dbSet.SingleOrDefault(s => s.Name == name);
            return result;
        }

        public IList<MenuCategory> GetByPosition()
        {
            var result = _dbSet.OrderBy(o => o.Position).ToList();
            return result;
        }

        public IList<string> GetCategoryNames()
        {
            var result = _dbSet.Select(s => s.Name).ToList();
            return result;
        }
    }
}
