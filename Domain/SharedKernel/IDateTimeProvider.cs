namespace Domain.SharedKernel;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}