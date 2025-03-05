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
    public class StudentService : IStudentSerivce
    {
        private readonly IGenericRepository<Student> _repository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public ValueTask AddAsync(StudentDto entity)
        {
            _repository.CreateAsync(_mapper.Map<Student>(entity));
            return ValueTask.CompletedTask;
        }

        public ValueTask DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
            return ValueTask.CompletedTask;
        }

        public async ValueTask<bool> Exist(int id)
        {
            return  await _repository.Exist(p => p.Id == id);
            
        }

        public async ValueTask<IEnumerable<StudentDto>> GetAllAsync(int pageNumber = 0, int pageSize = 10, Expression<Func<Student, bool>> predicate = null)
        {
            var entites = await _repository.GetAllAsync(pageNumber, pageSize,predicate);
            var Dtos = _mapper.Map<IEnumerable<StudentDto>>(entites);

            return Dtos;
        }

     

       
        public async ValueTask<StudentDto?> GetByIdAsync(int id)
        {
           return _mapper.Map<StudentDto>(await _repository.GetByIdAsync(id));
        }
        public ValueTask UpdateAsync(StudentDto entity)
        {
           var student = _mapper.Map<Student>(entity);
            _repository.UpdateAsync(student);
            return ValueTask.CompletedTask;
        }

       
    }
}
