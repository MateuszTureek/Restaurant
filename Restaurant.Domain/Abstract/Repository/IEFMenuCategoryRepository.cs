using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Abstract.Repository
{
    public interface IEFMenuCategoryRepository : IEFRepository<MenuCategory>
    {
        IList<MenuCategory> GetByPosition();
        IList<string> GetCategoryNames();
        MenuCategory GetByName(string name);
    }
}
