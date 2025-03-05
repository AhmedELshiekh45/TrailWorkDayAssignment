using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using Domain.Models;
using ServiceLayer.Generic;

namespace ServiceLayer.Services.EnrollementServices
{
    public interface IEnrollmentService : IGenericService<EnrollmentDto, Enrollment>
    {
        ValueTask<bool> Exist(int classid, int studentid);
    }
}
