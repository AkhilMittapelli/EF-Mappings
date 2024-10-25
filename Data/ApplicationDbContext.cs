using EF_Mappings.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Mappings.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<Size> sizes { get; set; }
        public DbSet<color> colors { get; set; }
    }
}
