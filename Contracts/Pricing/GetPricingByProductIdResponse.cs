namespace Contracts.Pricing;

public record ProductPrice(Guid ProductId, string Location, decimal CalculatedPrice, DateTime LastUpdated);

public record GetPricingByProductIdResponse(IEnumerable<ProductPrice> ProductPrices);