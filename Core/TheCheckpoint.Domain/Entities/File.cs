using TheCheckpoint.Domain.Entities.Common;

namespace TheCheckpoint.Domain.Entities
{
    public class File:BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
