namespace Presentaion.EndPoints.ClassEndPoints
{
    using System.Diagnostics.Metrics;
    using System.Linq.Expressions;
    using Domain.Constant;
    using Domain.DTOS;
    using Domain.Models;
    using FastEndpoints;
    using Microsoft.AspNetCore.Http.HttpResults;
    using ServiceLayer.Generic;
    using ServiceLayer.Services.ClassServices;

    namespace Presentaion.EndPoints.StudentEndpoints
    {
        public class GetAll : Ep.Req<PaginationRequest>.Res<IEnumerable<ClassDto>>
        {
            private readonly IClassService _service;

            public GetAll(IClassService service)
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
                Expression<Func<Class, bool>> predicate = null;

                // Apply filtering if searchTerm is provided
                if (!string.IsNullOrEmpty(req.filter))
                {
                    predicate = Class => Class.Name.Contains(req.filter) || Class.Description.Contains(req.filter);
                }
                return (await _service.GetAllAsync(req.PageNumber??1, req.PageSize??10,predicate));
            }
        }
    }

}
