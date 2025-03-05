using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Generic
{
    public interface IGenericService<TDto,TEntity> where TDto : class
    {
        ValueTask<IEnumerable<TDto>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate = null);
        ValueTask<TDto?> GetByIdAsync(int id);
        ValueTask AddAsync(TDto entity);
        ValueTask UpdateAsync(TDto entity);
        ValueTask DeleteAsync(int id);
    }

}
