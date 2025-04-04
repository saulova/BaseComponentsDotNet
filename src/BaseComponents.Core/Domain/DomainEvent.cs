namespace BaseComponents.Core.Domain;

public abstract class DomainEvent : IEvent
{
    public Guid EventId { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
}