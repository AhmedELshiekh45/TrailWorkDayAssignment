using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using Domain.Models;
using ServiceLayer.Generic;

namespace ServiceLayer.Services.StudentServices
{
    public interface IStudentSerivce:IGenericService<StudentDto,Student>
    {
        ValueTask<bool> Exist(int id);
        ValueTask<StudentReportDto> GetReport(int id);
    }
}
