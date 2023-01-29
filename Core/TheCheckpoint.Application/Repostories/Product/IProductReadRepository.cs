using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheckpoint.Domain.Entities;

namespace TheCheckpoint.Application.Repostories
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
