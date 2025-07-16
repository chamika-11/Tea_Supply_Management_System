namespace Tea_Management.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}