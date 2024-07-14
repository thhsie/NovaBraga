namespace Contracts.Pricing;

public sealed record CreatePricingRequest(
    Guid ProductId, 
    string Location, 
    decimal CalculatedPrice
    );