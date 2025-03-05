namespace Presentaion.EndPoints.ClassEndPoints
{
    using Domain.DTOS;
    using Domain.Models;
    using FastEndpoints;
    using Microsoft.AspNetCore.Authorization;
    using ServiceLayer.Generic;
    using ServiceLayer.Services.ClassServices;

    namespace Presentaion.EndPoints.StudentEndpoints
    {
        [HttpDelete("/api/classes/{id}")]
        [AllowAnonymous]
        public class Delete : Ep.NoReq.NoRes
        {
            private readonly IClassService service;

            public Delete(IClassService service)
            {

                this.service = service;
            }
            public override async Task HandleAsync(CancellationToken ct)
            {
                int ID = Route<int>("id");  // Read route value
                var student = await service.GetByIdAsync(ID);
                if (student == null)
                {
                    await SendNotFoundAsync();
                }
                await service.DeleteAsync(ID);
            }

        }
    }

}
