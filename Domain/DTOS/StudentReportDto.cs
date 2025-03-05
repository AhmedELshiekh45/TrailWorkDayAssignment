using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class StudentReportDto
    {
        public List<ClassMarkDto>? StudentClassMarks { get; set; }
        public decimal OverAllAverageMarksForAllClasses => StudentClassMarks.Select(p => p.ClassMark)?.Average()??0;


    }
}
