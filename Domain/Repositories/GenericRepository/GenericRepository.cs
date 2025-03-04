using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories.GenericRepositories;

namespace Domain.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseClass
    {
        private static readonly ConcurrentDictionary<int, TEntity> _entites = new();


        public ValueTask CreateAsync(TEntity entity)
        {
            _entites.TryAdd(entity.Id, entity);
            return ValueTask.CompletedTask;
        }

        public async ValueTask DeleteAsync(int id)
        {
            _entites.TryRemove(id, out _);
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync(int pagenumber, int pagesize, Expression<Func<TEntity, bool>> predicate = null)
        {
            var Query = _entites.Values.AsQueryable();
            if (predicate != null)
            {
                Query.Where(predicate);
            }
            return Query.Skip((pagenumber - 1) * pagesize)
                .Take(pagesize).ToList();
        }

        public async ValueTask<IQueryable<TEntity>> GetAsQuery()
        {
           return _entites.Values.AsQueryable();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return _entites[id];
        }

        public ValueTask UpdateAsync(TEntity entity)
        {
            _entites[entity.Id] = entity;
            return ValueTask.CompletedTask;
        }
    }
}
