using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheckpoint.Application.QueryParameters
{
    public record Pagination
    {
        public int Page { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
