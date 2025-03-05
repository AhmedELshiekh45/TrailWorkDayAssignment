using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.GenericRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        ValueTask CreateAsync(TEntity entity);
        ValueTask UpdateAsync(TEntity entity);
        ValueTask DeleteAsync(int id);
        ValueTask<bool> Exist(Func<TEntity, bool> predicate);

        ValueTask<TEntity?> GetByIdAsync(int id);
        ValueTask<IEnumerable<TEntity>> GetAllAsync(int pagenumber,int pagesize, Expression<Func<TEntity, bool>> predicate = null);
        ValueTask<IQueryable<TEntity>> GetAsQuery();
    }
}
