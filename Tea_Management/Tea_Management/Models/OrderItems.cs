namespace Tea_Management.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string Grade { get; set; }
        public double QuantityKg { get; set; }
    }
}

