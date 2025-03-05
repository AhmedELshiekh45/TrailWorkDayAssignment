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
using ServiceLayer.Services.MarkServces;

namespace ServiceLayer.Services.StudentServices
{
    public class StudentService : IStudentSerivce
    {
        private readonly IGenericRepository<Student> _studentrepository;
        private readonly IGenericRepository<Mark> _Markrepository;
        private readonly IGenericRepository<Class> _Classepository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> Studentrepository, IGenericRepository<Class> classrepo, IGenericRepository<Mark> markrepo, IMapper mapper, IMarkService markService)
        {
            this._studentrepository = Studentrepository;
            this._mapper = mapper;
            this._Markrepository = markrepo;
            this._Classepository = classrepo;
        }
        public ValueTask AddAsync(StudentDto entity)
        {
            _studentrepository.CreateAsync(_mapper.Map<Student>(entity));
            return ValueTask.CompletedTask;
        }

        public ValueTask DeleteAsync(int id)
        {
            _studentrepository.DeleteAsync(id);
            return ValueTask.CompletedTask;
        }

        public async ValueTask<bool> Exist(int id)
        {
            return await _studentrepository.Exist(p => p.Id == id);

        }

        public async ValueTask<IEnumerable<StudentDto>> GetAllAsync(int pageNumber = 0, int pageSize = 10, Expression<Func<Student, bool>> predicate = null)
        {
            var entites = await _studentrepository.GetAllAsync(pageNumber, pageSize, predicate);
            var Dtos = _mapper.Map<IEnumerable<StudentDto>>(entites);

            return Dtos;
        }




        public async ValueTask<StudentDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<StudentDto>(await _studentrepository.GetByIdAsync(id));
        }

        public async ValueTask<StudentReportDto> GetReport(int id)
        {
            var studentreport = new StudentReportDto();
            var entites = await _Markrepository.GetAsQuery();
            var x = entites.Where(p => p.StudentId == id);
            foreach (var item in x)
            {
                var Class = await _Classepository.GetByIdAsync(item.ClassId);
                studentreport.StudentClassMarks.Add(new ClassMarkDto { ClassId = item.ClassId, ClassName =Class?.Name??null , ClassMark = item.TotalMark });
            }
            return studentreport;
        }

        public ValueTask UpdateAsync(StudentDto entity)
        {
            var student = _mapper.Map<Student>(entity);
            _studentrepository.UpdateAsync(student);
            return ValueTask.CompletedTask;
        }


    }
}
