using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheckpoint.Domain.Entities.Common;

namespace TheCheckpoint.Application.Repostories
{
    public interface IRepository<T> where T:BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
