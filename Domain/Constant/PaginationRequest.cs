using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constant
{
    public class PaginationRequest
    {
        public int? PageNumber { get; set; }   // Default: First Page
        public int? PageSize { get; set; }   // Default: 10 Items per Page
        public string? filter { get; set; }  // serch filter by name or age
    }
}
