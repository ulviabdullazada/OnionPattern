using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheckpoint.Domain.Entities
{
    public class ProductImageFile:File
    {
        public bool IsCover { get; set; }
        public Product Product { get; set; }
    }
}
