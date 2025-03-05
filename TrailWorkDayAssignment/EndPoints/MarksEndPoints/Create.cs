using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;
using ServiceLayer.Services.EnrollementServices;
using ServiceLayer.Services.MarkServces;

namespace Presentaion.EndPoints.MarksEndPoints
{
  
    public class Create : Endpoint<MarkDto, Results<Ok<MarkDto>, Conflict<string>>>
    {
        private readonly IMarkService _markservice;
        private readonly IEnrollmentService _enrollmentservice;

        public Create(IMarkService markservice, IEnrollmentService enrollmentservice)
        {
            this._markservice = markservice;
            this._enrollmentservice = enrollmentservice;
           
        }
        public override void Configure()
        {
            Post("/api/marks");
            AllowAnonymous();
            Validator<MarkDtoValidator>(); // Attach the validator
        }
        public async override Task<Results<Ok<MarkDto>, Conflict<string>>> ExecuteAsync(MarkDto req, CancellationToken ct)
        {
            var student = await _enrollmentservice.Exist(req.ClassId, req.StudentId);
            if (!student)
            {
                return TypedResults.Conflict("this student not enrolled in this class please enroll and then retry");
            }
           await _markservice.AddAsync(req);
            return TypedResults.Ok(req);

        }
    }
}
