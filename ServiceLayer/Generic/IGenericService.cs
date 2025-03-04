using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Generic
{
    public interface IGenericService<T,TBaseEntity> where T : class
    {
        ValueTask<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<TBaseEntity, bool>> predicate = null);
        ValueTask<IEnumerable<T>> GetAllAsync( Expression<Func<TBaseEntity, bool>> predicate = null);
        ValueTask<T?> GetByIdAsync(int id);
        ValueTask AddAsync(T entity);
        ValueTask UpdateAsync(T entity);
        ValueTask DeleteAsync(int id);
    }

}
