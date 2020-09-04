using System;

namespace Domain
{
    public class Image
    {
        public int Id { get; set; }
        public Guid StorageId { get; set; }
        public string Uri { get; set; }
        public string FileType { get; set; }
    }
}
