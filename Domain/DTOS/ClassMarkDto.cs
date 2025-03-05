using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class ClassMarkDto
    {

        public int ClassId { get; set; }
        public string? ClassName { get; set; }

        public decimal ClassMark  { get; set; }
    }
}
