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
        private readonly IStudentSerivce _studentSerivce;

        public Report(IStudentSerivce studentSerivce)
        {
            this._studentSerivce = studentSerivce;
        }

        public override async Task<StudentReportDto> ExecuteAsync(CancellationToken ct)
        {
            var  Id = Route<int>("studentid");
         return  await  _studentSerivce.GetReport(Id);
            
        }
    }
}
