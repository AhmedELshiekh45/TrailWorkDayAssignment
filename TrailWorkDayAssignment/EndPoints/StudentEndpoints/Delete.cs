using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Generic;
using ServiceLayer.Services.StudentServices;

namespace Presentaion.EndPoints.StudentEndpoints
{
    [HttpDelete("/api/students/{id}")]
    [AllowAnonymous]
    public class Delete:Ep.NoReq.NoRes
    {
        private readonly IStudentSerivce _service;

        public Delete(IStudentSerivce service)
        {
            this._service = service;
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            int studentId = Route<int>("id");  // Read route value
            var student = await _service.GetByIdAsync(studentId);
            if (student == null)
            {
                await SendNotFoundAsync();
            }
           await _service.DeleteAsync(studentId);
        }

    }
}
