using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete.Repository
{
    public class EFDishRepository : EFRepository<Dish>, IEFDishRepository
    {
        public EFDishRepository(EFRestaurantDbContext context) : base(context)
        {
        }

        public IList<int> GetAssignedPositions()
        {
            var result = _dbSet.Select(s => s.Position).ToList();
            return result;
        }

        public IList<Dish> GetDishesByMenuCategoryOrderByPositionAsc(string categoryName)
        {
            IList<Dish> result = null;

            if (categoryName != null)
                result = _dbSet.Where(w => w.MenuCategory.Name == categoryName).OrderBy(o => o.Position).ToList();
            else
                result = _dbSet.OrderBy(o => o.Position).ToList();
            return result;
        }

        public IList<Dish> GetDishesByMenuCategoryOrderByPriceAsc(string categoryName)
        {
            IList<Dish> result = null;

            if (categoryName != null)
                result = _dbSet.Where(w => w.MenuCategory.Name == categoryName).OrderBy(o => o.Price).ToList();
            else
                result = _dbSet.OrderBy(o => o.Price).ToList();
            return result;
        }
    }
}
