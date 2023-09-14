using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoloftAPI.Core.Model
{
    public class PaginatedRequest
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? PageCount { get; set; }
        public int? TotalCount { get; set; }
        public int? TotalPages { get; set; }
    }
}
