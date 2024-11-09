namespace MouseApi.Models
{
    // Models/TodoItem.cs
    public class MouseItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class MouseDebts
    {
        public required MouseItem Debtor { get; set; }
        public required MouseItem Creditor { get; set; }
        public decimal Value { get; set;}
    }
}