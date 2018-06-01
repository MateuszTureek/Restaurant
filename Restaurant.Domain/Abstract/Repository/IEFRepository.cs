using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Abstract.Repository
{
    public interface IEFRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
        T GetById(int? id);
        IList<T> List();
        int AmountOfElements();
    }
}
