using Shofy.Cargo.DataAccessLayer.Abstract;
using Shofy.Cargo.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CargoDbContext _context;

        public Repository(CargoDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var value = _context.Set<T>().Find(id);
            return value;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
