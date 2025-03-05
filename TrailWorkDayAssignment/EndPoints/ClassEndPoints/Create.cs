namespace Presentaion.EndPoints.ClassEndPoints
{
    using Domain.DTOS;
    using Domain.Models;
    using FastEndpoints;
    using ServiceLayer.Generic;
    using ServiceLayer.Services.ClassServices;

    namespace Presentaion.EndPoints.StudentEndpoints
    {
        public class Create : Ep.Req<ClassDto>.NoRes
        {
            private readonly IClassService _service;

            public Create(IClassService service)
            {
                this._service = service;
            }
            public override void Configure()
            {
                Post("/api/classes");
                AllowAnonymous();
            }
            public override async Task HandleAsync(ClassDto req, CancellationToken ct)
            {
                await _service.AddAsync(req);
                await SendAsync(req, statusCode: 201);

            }
        }
    }

}
