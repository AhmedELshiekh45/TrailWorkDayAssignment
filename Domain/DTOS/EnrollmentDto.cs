﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime? EnrollmentDate { get; set; }= DateTime.Now;
    }
}
