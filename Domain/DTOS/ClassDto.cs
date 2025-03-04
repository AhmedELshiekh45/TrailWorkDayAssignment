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
        [Required,Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required,Length(minimumLength:5,maximumLength:100,ErrorMessage ="The Name Should Be More Than 5 chars And Less Than 100")]
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Description { get; set; }
    }
}
