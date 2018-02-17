using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repository.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);
        void Delete(int Id);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetObject(Expression<Func<T, bool>> lamda);
        IEnumerable<T> Where(Expression<Func<T, bool>> lamda);
        T FindById(int Id);


    }
}
