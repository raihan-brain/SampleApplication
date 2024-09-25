 using Microsoft.EntityFrameworkCore;

namespace SampleApplication.Models
{
    public class BillingContext : DbContext
    {
        private readonly IConfiguration _config;
        public BillingContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TimeBill> TimeBills => Set<TimeBill>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = _config.GetConnectionString("BillingDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    Id = 1,
                    AddressLine1 = "123 Main St",
                    City = "Anytown",
                    StateProvince = "NY",
                    PostalCode = "12345"
                },
                 new Address()
                 {
                     Id = 2,
                     AddressLine1 = "123 first avenue",
                     City = "Atlanta",
                     StateProvince = "GA",
                     PostalCode = "12345"
                 }
            );

            modelBuilder.Entity<Customer>().HasData(
                 new
                 {
                     Id = 1,
                     CompanyName = "Ajax",
                     AddressId = 1,
                     contact = "John Doe",
                     PhoneNumber = "123-456-7890"
                 },
                 new
                 {
                     Id = 2,
                     CompanyName = "Acme",
                     AddressId = 2,
                     contact = "Jane Doe",
                     PhoneNumber = "123-456-7890"
                 }
             );

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "John Doe",
                    BillingRate = 50.00f,
                    Email = "something@yopmail.com",
                    ImageUrl = "https://via.placeholder.com/150"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Jane Doe",
                    BillingRate = 60.00f,
                    Email = "test@yopmail.com",
                    ImageUrl = "https://via.placeholder.com/150"
                }
                );
        }
    }
}
