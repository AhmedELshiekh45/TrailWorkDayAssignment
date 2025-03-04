using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;

namespace Presentaion.EndPoints.StudentEndpoints
{
    public class Update : Ep.Req<StudentDto>.Res<NotFound>
    {
        private readonly IGenericService<StudentDto, Student> service;

        public Update(IGenericService<StudentDto, Student> service)
        {
            this.service = service;
        }
        public override void Configure()
        {
            Put($"/api/students/id");
            AllowAnonymous();
        }
        public override async Task HandleAsync(StudentDto req, CancellationToken ct)
        {
            int studentId = Route<int>("id");  // Read route value
            var student = await service.GetByIdAsync(studentId);
            if (student == null) { 
             await SendNotFoundAsync();
            }
            await service.UpdateAsync(req);

        }
    }
}
