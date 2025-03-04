using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOS;
using Domain.Models;

namespace ServiceLayer.Services.ClassServices.MappingProfiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {

            CreateMap<EnrollmentDto, Enrollment>()
                .ReverseMap();

            CreateMap<Mark, MarkDto>()
                .ReverseMap();
        }
    }
}
