namespace MouseApi.Models
{
    // Models/TodoItem.cs
    public class MouseItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
    }

}