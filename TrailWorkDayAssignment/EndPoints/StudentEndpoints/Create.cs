using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using ServiceLayer.Generic;

namespace Presentaion.EndPoints.StudentEndpoints
{
    public class Create:Ep.Req<StudentDto>.NoRes
    {
        private readonly IGenericService<StudentDto,Student> _service;

        public Create(IGenericService<StudentDto,Student> service)
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
