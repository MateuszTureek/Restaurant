using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete.Repository
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(EFRestaurantDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public int AmountOfElements()
        {
            var count = _dbSet.Count();
            return count;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T GetById(int? id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public IList<T> List()
        {
            var entities = _dbSet.ToList();
            return entities;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
