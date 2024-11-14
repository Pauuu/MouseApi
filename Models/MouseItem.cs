using System.Reflection.Metadata;

namespace MouseApi.Models
{
    // Models/TodoItem.cs
    public class MouseItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
        public MouseTest MouseTest { get; set; }
        public MouseFile? MouseFile { get; set; }
    }

    public class MouseTest
    {
        public long Id { get; set; }
        public string test { get; set; }
    }

    public class MouseFile { 
        public long Id { get; set; }
        public required string FileName { get; set; }
        public required string MimeType {  get; set; }
        public required byte[] Content{ get; set; }
    }

    public class MouseAloneFile
    {
        public long Id { get; set; }
        public required string FileName { get; set; }
        public required string MimeType { get; set; }
        public required byte[] Content { get; set; }
    }
}