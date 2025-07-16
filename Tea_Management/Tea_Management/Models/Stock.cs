namespace Tea_Management.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public double QuantityKg { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}

