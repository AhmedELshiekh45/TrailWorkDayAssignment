using Domain.DTOS;
using Domain.Models;
using Domain.Repositories.GenericRepositories;
using Domain.Repositories.GenericRepository;
using FastEndpoints;
using FastEndpoints.Swagger;
using ServiceLayer.Generic;
using ServiceLayer.Services.ClassServices;
using ServiceLayer.Services.EnrollementServices;
using ServiceLayer.Services.NewFolder.MarkServces;
using ServiceLayer.Services.StudentServices; //add this

var bld = WebApplication.CreateBuilder();
bld.Services
   .AddFastEndpoints()
   .SwaggerDocument(); //define a swagger document
bld.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
bld.Services.AddScoped<IGenericService<MarkDto, Mark>, StudentService>();
bld.Services.AddScoped<IGenericService<MarkDto, Mark>, ClassService>();
bld.Services.AddScoped<EnrollmentService>();
bld.Services.AddScoped<MarkService>();
bld.Services.AddScoped<IGenericService<EnrollmentDto, Enrollment>,EnrollmentService>();
bld.Services.AddScoped<IGenericService<MarkDto, Mark>,MarkService>();


bld.Services.AddAutoMapper(typeof(StudentService).Assembly);


var app = bld.Build();
app.UseFastEndpoints()
   .UseSwaggerGen(); //add this
app.Run();
