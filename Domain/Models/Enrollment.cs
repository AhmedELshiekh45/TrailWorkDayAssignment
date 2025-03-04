using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Enrollment : BaseClass
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
