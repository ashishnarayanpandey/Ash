using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ash.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Get all, Get by id First or Default, Add, Remove and RemoveRange
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby=null,
            string ? includeProperties=null);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    }
}
