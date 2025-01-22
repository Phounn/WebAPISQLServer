using Data.Data;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContosoPizzaContext _context;
        private readonly DbSet<T>? _dbSet;
        public Repository(ContosoPizzaContext context) // #2 (Next) ProductController
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()//#5 (Next) ProductController
        {
            return _dbSet!.ToList();
        }
        public T GetById(int id)
        {
            var content = _dbSet?.Find(id);
            return content!;
        }
        public void Create(T entity)
        {
            var content = entity;
            _dbSet?.Add(entity);
        }

        public void Delete(int Id)
        {
            var content = _dbSet?.Find(Id);
            _context?.Remove(content);
        }
    }
}
