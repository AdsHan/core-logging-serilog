using LSE.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LSE.Catalog.Infrastructure.Data
{
    public class CatalogDbContext : DbContext
    {

        public CatalogDbContext()
        {

        }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }

    }
}
