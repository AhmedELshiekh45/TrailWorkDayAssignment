using System.Collections.Concurrent;
using Domain.DTOS;
using Domain.Models;
using Domain.Repositories.GenericRepositories;
using Domain.Repositories.GenericRepository;
using FastEndpoints;
using FastEndpoints.Swagger;
using ServiceLayer.Generic;
using ServiceLayer.Services.ClassServices;
using ServiceLayer.Services.EnrollementServices;
using ServiceLayer.Services.MarkServces;
using ServiceLayer.Services.StudentServices; //add this

var bld = WebApplication.CreateBuilder();
bld.Services
   .AddFastEndpoints()
   .SwaggerDocument(); //define a swagger document

bld.Services.AddSingleton(typeof(ConcurrentDictionary<int, Student>));
bld.Services.AddSingleton(typeof(ConcurrentDictionary<int, Enrollment>));
bld.Services.AddSingleton(typeof(ConcurrentDictionary<int, Class>));
bld.Services.AddSingleton(typeof(ConcurrentDictionary<int, Mark>));


bld.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
bld.Services.AddScoped<IStudentSerivce, StudentService>();
bld.Services.AddScoped<IClassService, ClassService>();
bld.Services.AddScoped<IEnrollmentService,EnrollmentService>();
bld.Services.AddScoped<IMarkService,MarkService>();


bld.Services.AddAutoMapper(typeof(StudentService).Assembly);


var app = bld.Build();
app.UseFastEndpoints()
   .UseSwaggerGen(); //add this
app.Run();
