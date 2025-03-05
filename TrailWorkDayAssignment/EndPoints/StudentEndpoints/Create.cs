using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using ServiceLayer.Generic;
using ServiceLayer.Services.StudentServices;

namespace Presentaion.EndPoints.StudentEndpoints
{
    public class Create:Ep.Req<StudentDto>.NoRes
    {
        private readonly IStudentSerivce _service;

        public Create(IStudentSerivce service)
        {
            this._service = service;
        }
        public override void Configure()
        {
            Post("api/students");
            AllowAnonymous();
        }
        public override async Task HandleAsync(StudentDto req, CancellationToken ct)
        {
           await _service.AddAsync(req);
            await SendAsync(req,statusCode:201);
            
        }
    }
}
