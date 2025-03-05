using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class ClassDto
    {
        private static int _nextId = 1; // عداد لتوليد الـ Id

        public int Id { get; set; } = _nextId++; // توليد الـ Id تلقائيًا
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Description { get; set; }
    }
}
