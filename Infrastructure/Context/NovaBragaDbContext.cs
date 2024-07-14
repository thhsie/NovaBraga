using Domain.Pricing;
using Domain.Products;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class NovaBragaDbContext(DbContextOptions<NovaBragaDbContext> dbContextOptions)
: BaseDbContext<NovaBragaDbContext>(dbContextOptions)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Pricing> Pricing => Set<Pricing>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new ProductConfiguration())
            .ApplyConfiguration(new PricingConfiguration());
    }
}