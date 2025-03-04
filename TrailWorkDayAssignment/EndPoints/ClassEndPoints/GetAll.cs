namespace Presentaion.EndPoints.ClassEndPoints
{
    using Domain.Constant;
    using Domain.DTOS;
    using Domain.Models;
    using FastEndpoints;
    using Microsoft.AspNetCore.Http.HttpResults;
    using ServiceLayer.Generic;

    namespace Presentaion.EndPoints.StudentEndpoints
    {
        public class GetAll : Ep.Req<PaginationRequest>.Res<IEnumerable<ClassDto>>
        {
            private readonly IGenericService<ClassDto, Class> _service;

            public GetAll(IGenericService<ClassDto, Class> service)
            {
                this._service = service;
            }
            public override void Configure()
            {
                Get("/api/classes");
                AllowAnonymous();
            }
            public override async Task<IEnumerable<ClassDto>> ExecuteAsync(PaginationRequest req, CancellationToken ct)
            {
                return (await _service.GetAllAsync(req.PageNumber, req.PageSize));
            }
        }
    }

}
