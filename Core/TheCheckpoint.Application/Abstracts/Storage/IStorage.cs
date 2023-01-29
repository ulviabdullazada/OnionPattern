using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheckpoint.Application.Abstracts.Storage
{
    public interface IStorage
    {
        Task<List<string>> UploadAsync(string pathOrContainer, ICollection<IFormFile> files);
        void Delete(string pathOrContainer);
        List<string> GetFiles (string pathOrContainer);
        bool HasFile(string pathOrContainer);
    }
}
