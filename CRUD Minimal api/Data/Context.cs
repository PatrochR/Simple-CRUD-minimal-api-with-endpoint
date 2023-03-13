

namespace CRUD_Minimal_api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
