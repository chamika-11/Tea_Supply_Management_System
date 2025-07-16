namespace Tea_Management.Models
{
    public class TeaCollection
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double WeightKg { get; set; }
        public string Grade { get; set; }
        public decimal RatePerKg { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}