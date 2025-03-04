using Domain.Constant;
using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;

namespace Presentaion.EndPoints.StudentEndpoints
{
    public class GetAll:Ep.Req<PaginationRequest>.Res<IEnumerable<StudentDto>>
    {
        private readonly IGenericService<StudentDto,Student> _service;

        public GetAll(IGenericService<StudentDto,Student> service)
        {
            this._service = service;
        }
        public override void Configure()
        {
            Get("/api/students");
            AllowAnonymous();
        }
        public override async Task<IEnumerable<StudentDto>> ExecuteAsync(PaginationRequest req, CancellationToken ct)
        {
            return ( await _service.GetAllAsync(req.PageNumber,req.PageSize));
        }
    }
}
