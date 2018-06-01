using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Abstract.Repository
{
    public interface IEFDishRepository : IEFRepository<Dish>
    {
        IList<Dish> GetDishesByMenuCategoryOrderByPositionAsc(string categoryName);
        IList<Dish> GetDishesByMenuCategoryOrderByPriceAsc(string categoryName);
        IList<int> GetAssignedPositions();
    }
}
