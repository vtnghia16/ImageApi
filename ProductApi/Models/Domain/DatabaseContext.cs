using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {

        }

        // Set data mapping csdl
        public DbSet<Product> Product { get; set;}
    }
}
