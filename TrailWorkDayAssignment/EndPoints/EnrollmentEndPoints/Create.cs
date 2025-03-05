using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;
using ServiceLayer.Services.EnrollementServices;

namespace Presentaion.EndPoints.EnrollmentEndPoints
{
    [HttpPost("/api/enrollments")]
    [AllowAnonymous]
    public class Create:Endpoint<EnrollmentDto,Results<Ok<EnrollmentDto>,Conflict<string>>>
    {
        private readonly IEnrollmentService _service;

        public Create(IEnrollmentService service)
        {
            this._service = service;
        }
        public async override Task<Results<Ok<EnrollmentDto>, Conflict<string>>> ExecuteAsync(EnrollmentDto req, CancellationToken ct)
        {
            var enrollment = await _service.GetByIdAsync(req.Id);
            
            if (enrollment != null)
            {
                return TypedResults.Conflict("already enrolled");
            }
           
            await _service.AddAsync(req);
            return TypedResults.Ok(req);
        }


    }
}
