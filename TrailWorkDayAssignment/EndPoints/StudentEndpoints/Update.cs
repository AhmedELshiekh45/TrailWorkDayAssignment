using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;
using ServiceLayer.Services.StudentServices;

namespace Presentaion.EndPoints.StudentEndpoints
{
    public class Update : Ep.Req<StudentDto>.Res<NotFound>
    {
        private readonly IStudentSerivce _service;

        public Update(IStudentSerivce service)
        {
            this._service = service;
        }
        public override void Configure()
        {
            Put("/api/students/{id}");
            AllowAnonymous();
            Validator<StudentDtoValidator>(); // Attach the validator

        }
        public override async Task HandleAsync(StudentDto req, CancellationToken ct)
        {
            int studentId = Route<int>("id");  // Read route value
            var student = await _service.GetByIdAsync(studentId);
            if (student == null) { 
             await SendNotFoundAsync();
            }
            await _service.UpdateAsync(req);

        }
    }
}
