using Tea_Management.Models;


namespace TeaManagement.Data
{

    public static class DbInitializer
    {
        public static void Initialize(TeaDbContext context)

        {
            context.Database.EnsureCreated();

            if (context.Factories.Any())
            {
                return;
            }

            var factories = new Factory[]
            {
                new Factory { Name = "Green Leaf Factory", Location = "Kandy" },
                new Factory { Name = "Highland Tea Factory", Location = "Nuwara Eliya" }
            };
            context.Factories.AddRange(factories);
            context.SaveChanges();

            var suppliers = new Supplier[]
            {
                new Supplier { FullName = "Chamika Silva", NIC = "991234567V", ContactNumber = "0771234567", FactoryId = factories[0].Id },
                new Supplier { FullName = "Nuwan Perera", NIC = "982345678V", ContactNumber = "0712345678", FactoryId = factories[1].Id }
            };
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            var collections = new TeaCollection[]
            {
                new TeaCollection { SupplierId = suppliers[0].Id, Date = DateTime.Today, WeightKg = 25.5, Grade = "BOP", RatePerKg = 120 },
                new TeaCollection { SupplierId = suppliers[1].Id, Date = DateTime.Today.AddDays(-1), WeightKg = 30.2, Grade = "Dust", RatePerKg = 100 }
            };
            context.TeaCollections.AddRange(collections);
            context.SaveChanges();
        }
    }
}