using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOS;
using Domain.Models;
using Domain.Repositories.GenericRepositories;
using ServiceLayer.Generic;

namespace ServiceLayer.Services.StudentServices
{
    public class StudentService : IGenericService<MarkDto,Mark>
    {
        private readonly IGenericRepository<Mark> _repository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Mark> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public ValueTask AddAsync(MarkDto entity)
        {
            _repository.CreateAsync(_mapper.Map<Mark>(entity));
            return ValueTask.CompletedTask;
        }

        public ValueTask DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> Exist()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IEnumerable<MarkDto>> GetAllAsync(int pageNumber = 0, int pageSize = 10, Expression<Func<Mark, bool>> predicate = null)
        {
            var entites = await _repository.GetAllAsync(pageNumber, pageSize,predicate);
            var Dtos = _mapper.Map<IEnumerable<MarkDto>>(entites);

            return Dtos;
        }

        public ValueTask<IEnumerable<MarkDto>> GetAllAsync(Expression<Func<Mark, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

       
        public async ValueTask<MarkDto?> GetByIdAsync(int id)
        {
           return _mapper.Map<MarkDto>(await _repository.GetByIdAsync(id));
        }
        public ValueTask UpdateAsync(MarkDto entity)
        {
           var student = _mapper.Map<Mark>(entity);
            _repository.UpdateAsync(student);
            return ValueTask.CompletedTask;
        }

       
    }
}
