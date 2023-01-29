using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheckpoint.Application.Abstracts.Storage.Local;

namespace TheCheckpoint.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        IWebHostEnvironment _env { get; }

        public LocalStorage(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void Delete(string path)
        {
            try
            {
                if (HasFile(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path)
            => File.Exists(path);
        async Task<bool> SaveAsync(string path, IFormFile file)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<string>> UploadAsync(string path, ICollection<IFormFile> files)
        {
            path = Path.Combine(_env.WebRootPath, path);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            List<string> strings = new List<string>();
            foreach (IFormFile file in files)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                bool result = await SaveAsync(Path.Combine(path, fileName), file);
                if (result)
                {
                    strings.Add(fileName);
                }
            }
            return strings;
        }
    }
}
