using Domain.DTOS;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceLayer.Services.StudentServices;

namespace Presentaion.EndPoints.StudentEndpoints
{
    [HttpGet("api/students/{studentid}/report")]
    [AllowAnonymous]
    public class Report : Ep.NoReq.Res<StudentReportDto>
    {
        private readonly IStudentSerivce studentSerivce;

        public Report(IStudentSerivce studentSerivce)
        {
            this.studentSerivce = studentSerivce;
        }

        public override Task<StudentReportDto> ExecuteAsync(CancellationToken ct)
        {
            var  Id = Route<int>("studentid");
            
        }
    }
}
