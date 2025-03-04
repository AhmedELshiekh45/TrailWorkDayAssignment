using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constant
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; } = 1;  // Default: First Page
        public int PageSize { get; set; } = 10;   // Default: 10 Items per Page
    }
}
