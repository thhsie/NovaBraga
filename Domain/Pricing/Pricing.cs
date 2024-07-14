using Domain.SharedKernel;

namespace Domain.Pricing;

public class Pricing : Entity
{
    private Pricing(Guid id, 
            Guid productId, 
            string location, 
            decimal calculatedPrice, 
            DateTime lastUpdated) : base(id)
    {
        ProductId = productId;
        Location = location;
        CalculatedPrice = calculatedPrice;
        LastUpdated = lastUpdated;
    }
    
    public Guid ProductId { get; private set; }
    
    public string Location { get; private set; }
    
    public decimal CalculatedPrice { get; private set; }
    
    public DateTime LastUpdated { get; private set; }

    public static Pricing Create(
        Guid productId, 
        string location, 
        decimal calculatedPrice, 
        DateTime lastUpdated)
    {
        var pricing = new Pricing(Guid.NewGuid(), productId, location, calculatedPrice, lastUpdated);

        return pricing;
    }
}