using System.Linq.Expressions;
using Domain.Constant;
using Domain.DTOS;
using Domain.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Generic;
using ServiceLayer.Services.StudentServices;

namespace Presentaion.EndPoints.StudentEndpoints
{
    public class GetAll:Ep.Req<PaginationRequest>.Res<IEnumerable<StudentDto>>
    {
        private readonly IStudentSerivce _service;

        public GetAll(IStudentSerivce service)
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
            int age;
            Expression<Func<Student, bool>> predicate = null;

            // Apply filtering if searchTerm is provided
            if (!string.IsNullOrEmpty(req.filter))
            {
                // Step 1: Check if req.filter is a valid integer
                if (int.TryParse(req.filter, out  age))
                {
                    // Step 2: Filter students by Age
                    predicate = Student => Student.Age == age;
                }
                else
                {
                    // Step 3: Filter students by FirstName
                    predicate = Student => Student.FirstName.Contains(req.filter, StringComparison.OrdinalIgnoreCase);
                }

            }
            return (await _service.GetAllAsync(req.PageNumber ?? 1, req.PageSize ?? 10, predicate));
        }
    }
}
