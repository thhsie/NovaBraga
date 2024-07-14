namespace Domain.Primitives;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}