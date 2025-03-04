using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;

namespace Presentaion.EndPoints.EnrollmentEndPoints
{
    [HttpPost("/api/enrollments")]
    [AllowAnonymous]
    public class Create:Endpoint<EnrollmentDto,Results<Ok<EnrollmentDto>,Conflict>>
    {
        private readonly IGenericService<EnrollmentDto, Enrollment> _service;

        public Create(IGenericService<EnrollmentDto,Enrollment> service)
        {
            this._service = service;
        }
        public async override Task<Results<Ok<EnrollmentDto>, Conflict>> ExecuteAsync(EnrollmentDto req, CancellationToken ct)
        {
            var enrollment = await _service.GetByIdAsync(req.Id);
            
            if (enrollment != null)
            {
                return TypedResults.Conflict();
            }
            await _service.AddAsync(req);
            return TypedResults.Ok(req);
        }


    }
}
