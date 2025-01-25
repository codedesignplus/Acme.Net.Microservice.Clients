namespace Acme.Net.Microservice.Clients.Domain.DomainEvents;

[EventKey<ClientAggregate>(1, "ClientInactivatedDomainEvent")]
public class ClientInactivatedDomainEvent(
     Guid aggregateId,
     bool isActive,
     Instant? updatedAt,
     Guid? updatedBy,
     Guid? eventId = null,
     Instant? occurredAt = null,
     Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public bool IsActive { get; } = isActive;
    public Instant? UpdatedAt { get; } = updatedAt;
    public Guid? UpdatedBy { get; } = updatedBy;

    public static ClientInactivatedDomainEvent Create(
        Guid aggregateId,
        bool isActive,
        Instant? updatedAt,
        Guid? updatedBy
    )
    {
        return new ClientInactivatedDomainEvent(aggregateId, isActive, updatedAt, updatedBy);
    }
}