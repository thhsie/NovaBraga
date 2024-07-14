using Domain.SharedKernel;

namespace Domain.Products;

public class Product : Entity
{
    private Product(Guid id, string title, string description, string category, DateTime yearMade) : base(id)
    {
        Title = title;
        Description = description;
        Category = category;
        YearMade = yearMade;
        Category = category;
    }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public string Category { get; private set; }
    
    public DateTime YearMade { get; private set; }

    public static Product Create(string title, string description, string category, DateTime yearMade)
    {
        var product = new Product(Guid.NewGuid(), title, description, category, yearMade);

        return product;
    }
}