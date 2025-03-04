using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOS;
using Domain.Models;
using Domain.Repositories.GenericRepositories;
using ServiceLayer.Generic;

namespace ServiceLayer.Services.ClassServices
{
    public class ClassService : IGenericService<MarkDto,Mark>
    {
        private readonly IGenericRepository<Mark> _repository;
        private readonly IMapper _mapper;

        public ClassService(IGenericRepository<Mark> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async ValueTask AddAsync(MarkDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Mark>(entity));
        }

        public async ValueTask DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public ValueTask<bool> Exist()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IEnumerable<MarkDto>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<Mark, bool>> predicate = null)
        {
           
            var result = await _repository.GetAllAsync(pageNumber, pageSize,predicate);
            var Dtos = _mapper.Map<IEnumerable<MarkDto>>(result);
            return Dtos;
        }

        public ValueTask<IEnumerable<MarkDto>> GetAllAsync(Expression<Func<Mark, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<MarkDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<MarkDto?>(await _repository.GetByIdAsync(id));
        }

        public async ValueTask UpdateAsync(MarkDto entity)
        {
           await _repository.UpdateAsync(_mapper.Map<Mark>(entity));
        }
    }
}
