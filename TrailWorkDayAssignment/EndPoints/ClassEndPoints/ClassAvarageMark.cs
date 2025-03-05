using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;
using ServiceLayer.Services.MarkServces;

namespace Presentaion.EndPoints.ClassEndPoints
{
    [HttpGet("/api/classes/{classid}/average-marks")]
    [AllowAnonymous]
    public class ClassAvarageMark : EndpointWithoutRequest<Results<Ok<decimal>, NotFound<string>>>
    {
        private readonly IMarkService _markService;

        //private readonly IGenericService<MarkDto, Mark> service;

        public ClassAvarageMark(IMarkService markService)
        {
            this._markService = markService;
        }

        public override async Task<Results<Ok<decimal>, NotFound<string>>> ExecuteAsync(CancellationToken ct)
        {
            int ID = Route<int>("classid");
            if (ID == null)
            {
                return TypedResults.NotFound("This Id Is Not Valid");
            }// Read route value
            return TypedResults.Ok(await _markService.GetAvargeMarksForClass(ID));
        }
    }
}
