using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using ServiceLayer.Generic;

namespace Presentaion.EndPoints.StudentEndpoints
{
    [HttpDelete("/api/students/{id}")]
    public class Delete:Ep.NoReq.NoRes
    {
        private readonly IGenericService<StudentDto, Student> service;

        public Delete(IGenericService<StudentDto, Student> service)
        {

            this.service = service;
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            int studentId = Route<int>("id");  // Read route value
            var student = await service.GetByIdAsync(studentId);
            if (student == null)
            {
                await SendNotFoundAsync();
            }
           await service.DeleteAsync(studentId);
        }

    }
}
