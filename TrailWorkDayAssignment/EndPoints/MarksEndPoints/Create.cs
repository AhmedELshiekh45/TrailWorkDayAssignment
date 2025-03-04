using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;
using ServiceLayer.Services.EnrollementServices;

namespace Presentaion.EndPoints.MarksEndPoints
{
    [HttpPost("/api/marks")]
    [AllowAnonymous]
    public class Create : Endpoint<MarkDto, Results<Ok<MarkDto>, Conflict<string>>>
    {
        private readonly IGenericService<MarkDto, Mark> _markservice;
        private readonly EnrollmentService _enrollmentservice;

        public Create(IGenericService<MarkDto,Mark> markservice, EnrollmentService enrollmentservice)
        {
            this._markservice = markservice;
            this._enrollmentservice = enrollmentservice;
           
        }
        public async override Task<Results<Ok<MarkDto>, Conflict<string>>> ExecuteAsync(MarkDto req, CancellationToken ct)
        {
            var student = await _enrollmentservice.Exist(req.ClassId, req.StudentId);
            if (student)
            {
                return TypedResults.Conflict("this is already exists");
            }
           await _markservice.AddAsync(req);
            return TypedResults.Ok(req);

        }
    }
}
