namespace Domain.SharedKernel;

public abstract class Entity : IEntity<Guid>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    protected Entity(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private init; }
}