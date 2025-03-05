using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class MarkDto
    {
        private static int _nextId = 1; // عداد لتوليد الـ Id

        public int Id { get; set; } = _nextId++; // توليد الـ Id تلقائيًا

        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal ExamMark { get; set; }
        public decimal AssignmentMark { get; set; }
    }
}
