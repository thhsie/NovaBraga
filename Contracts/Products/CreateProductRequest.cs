namespace Contracts.Products;

public sealed record CreateProductRequest(string Title, string Description, string Category, DateTime YearMade);