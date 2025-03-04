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

namespace ServiceLayer.Services.EnrollementServices
{
    public class EnrollmentService : IGenericService<EnrollmentDto, Enrollment>
    {
        private readonly IGenericRepository<Enrollment> _repository;
        private readonly IMapper _mapper;

        public EnrollmentService(IGenericRepository<Enrollment> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async ValueTask AddAsync(EnrollmentDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Enrollment>(entity));
        }

        public async ValueTask DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async ValueTask<bool> Exist(int studentid, int classid)
        {
            var query = await _repository.GetAsQuery();
            return query.Any(p => p.ClassId == classid && p.StudentId == studentid);
        }


       
        public async ValueTask<IEnumerable<EnrollmentDto>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<Enrollment, bool>> predicate = null)
        {
            var result = await _repository.GetAllAsync(pageNumber, pageSize, predicate);
            var Dtos = _mapper.Map<IEnumerable<EnrollmentDto>>(result);
            return Dtos;
        }

        public ValueTask<IEnumerable<EnrollmentDto>> GetAllAsync(Expression<Func<Enrollment, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<EnrollmentDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<EnrollmentDto?>(await _repository.GetByIdAsync(id));
        }

        public async ValueTask UpdateAsync(EnrollmentDto entity)
        {
            await _repository.UpdateAsync(_mapper.Map<Enrollment>(entity));
        }
    }
}
