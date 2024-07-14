using AutoMapper;

namespace Application.Mappings;

public class PricingMappingProfile : Profile
{
    public PricingMappingProfile()
    {
        // GetPricingByProductResponse
        CreateMap<Domain.Pricing.Pricing, Contracts.Pricing.ProductPrice>();
    }
}
