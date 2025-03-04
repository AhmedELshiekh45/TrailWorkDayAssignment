﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOS;
using Domain.Models;

namespace ServiceLayer.Services.StudentServices.MappingProfile
{
    public class StudentProfile :Profile
    {
        public StudentProfile()
        {
            CreateMap<MarkDto, Mark>()
                .ReverseMap();

            CreateMap<MarkDto,Mark >()
                .ReverseMap();
            
          
        }
    }
}
