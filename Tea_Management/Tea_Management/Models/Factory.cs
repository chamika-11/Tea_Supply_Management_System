namespace Tea_Management.Models
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}
