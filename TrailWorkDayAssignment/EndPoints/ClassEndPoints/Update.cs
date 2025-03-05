namespace Presentaion.EndPoints.ClassEndPoints
{
    using Domain.DTOS;
    using Domain.Models;
    using FastEndpoints;
    using Microsoft.AspNetCore.Http.HttpResults;
    using ServiceLayer.Generic;
    using ServiceLayer.Services.ClassServices;

    namespace Presentaion.EndPoints.StudentEndpoints
    {
        public class Update : Ep.Req<ClassDto>.Res<Results<Ok<string>,NotFound>>
        {
            private readonly IClassService service;

            public Update(IClassService service)
            {
                this.service = service;
            }
            public override void Configure()
            {
                Put("/api/classes/{id}");
                AllowAnonymous();
                Validator<ClassDtoValidator>(); // Attach the validator

            }
            public override async Task HandleAsync(ClassDto req, CancellationToken ct)
            {
                int id = Route<int>("id");  // Read route value
                var student = await service.GetByIdAsync(id);
                if (student == null)
                {
                    await SendNotFoundAsync();
                }
                await service.UpdateAsync(req);
                await SendAsync(TypedResults.Ok("Updated SuccessFully"),200);
            }
        }
    }

}
