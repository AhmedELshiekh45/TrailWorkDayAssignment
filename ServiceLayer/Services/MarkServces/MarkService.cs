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

namespace ServiceLayer.Services.MarkServces
{
    public class MarkService : IMarkService
    {
        private readonly IGenericRepository<Mark> _repository;
        private readonly IMapper _mapper;

        public MarkService(IGenericRepository<Mark> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

     
        public async ValueTask<decimal> GetAvargeMarksForClass(int classid)
        {
            var result = await _repository.GetAsQuery();
            var result2 = result.Where(p => p.ClassId == classid).Select(p => p.TotalMark).ToList();
            if (result2.Count == 0)
                return 0;
            return result2.Average();
        }
        public async ValueTask<IEnumerable<MarkDto>> GetAllAsync(int pageNumber = 0, int pageSize = 10, Expression<Func<Mark, bool>> predicate = null)
        {
            var entites = await _repository.GetAllAsync(pageNumber, pageSize, predicate);
            var Dtos = _mapper.Map<IEnumerable<MarkDto>>(entites);

            return Dtos;
        }
        public async ValueTask<bool> Exist(int id)
        {
            return await _repository.Exist(p => p.Id == id);

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

