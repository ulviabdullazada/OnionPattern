using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheckpoint.Domain.Entities.Common;

namespace TheCheckpoint.Application.ViewModels
{
    public class PaginatedList<T> where T:BaseEntity
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Datas { get; set; }
    }
}
