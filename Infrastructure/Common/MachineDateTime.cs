using Domain.SharedKernel;

namespace Infrastructure.Common;

internal sealed class MachineDateTime : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}