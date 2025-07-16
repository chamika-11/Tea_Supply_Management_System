namespace Tea_Management.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NIC { get; set; }
        public string ContactNumber { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }

        public ICollection<TeaCollection> Collections { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
