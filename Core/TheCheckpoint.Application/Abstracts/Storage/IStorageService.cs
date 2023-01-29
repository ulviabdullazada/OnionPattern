using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheckpoint.Application.Abstracts.Storage
{
    public interface IStorageService:IStorage
    {
        public string ServiceName { get; }
    }
}
