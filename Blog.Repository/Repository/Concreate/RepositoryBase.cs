using Blog.Repository.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repository.Concreate
{
    public class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        protected DbContext _dbContext;
        protected IDbSet<T> _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);

        }

        public void Delete(int Id)
        {
            var entity = _dbSet.Find(Id);
            _dbSet.Remove(entity);

        }

        public T FindById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Update(T entity)
        {
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;

        }


        public T GetObject(Expression<Func<T, bool>> lamda)
        {
            return _dbSet.FirstOrDefault(lamda);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lamda)
        {
            return _dbSet.Where(lamda).AsEnumerable<T>();
        }
    }
}
