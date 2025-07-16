namespace Tea_Management.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
