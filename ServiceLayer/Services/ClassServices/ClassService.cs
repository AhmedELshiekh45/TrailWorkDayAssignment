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
    public class ClassService : IClassService
    {
        private readonly IGenericRepository<Class> _repository;
        private readonly IMapper _mapper;

        public ClassService(IGenericRepository<Class> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async ValueTask AddAsync(ClassDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Class>(entity));
        }

        public async ValueTask DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

      
        public async ValueTask<IEnumerable<ClassDto>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<Class, bool>> predicate = null)
        {
           
            var result = await _repository.GetAllAsync(pageNumber, pageSize,predicate);
            var Dtos = _mapper.Map<IEnumerable<ClassDto>>(result);
            return Dtos;
        }

        public async ValueTask<bool> Exist(int id)
        {
            return await _repository.Exist(p => p.Id == id);

        }
        public async ValueTask<ClassDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ClassDto?>(await _repository.GetByIdAsync(id));
        }

        public async ValueTask UpdateAsync(ClassDto entity)
        {
           await _repository.UpdateAsync(_mapper.Map<Class>(entity));
        }
    }
}
