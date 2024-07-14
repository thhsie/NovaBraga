using Domain.Pricing;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
{
    public void Configure(EntityTypeBuilder<Pricing> builder)
    {
        builder
            .ConfigureBaseEntity();

        builder
            .Property(pricing => pricing.ProductId)
            .IsRequired();

        builder
            .Property(pricing => pricing.CalculatedPrice)
            .IsRequired();

        builder
            .Property(pricing => pricing.Location)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(pricing => pricing.LastUpdated)
            .IsRequired();
    }
}