using Domain.Products;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ConfigureBaseEntity();

        builder
            .Property(product => product.Title)
            .IsRequired();

        builder
            .Property(product => product.Description)
            .IsRequired();

        builder
            .Property(product => product.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(product => product.YearMade)
            .IsRequired();
    }
}