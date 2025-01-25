using Acme.Net.Microservice.Clients.Domain.ValueObjects;

namespace Acme.Net.Microservice.Clients.Domain.DomainEvents;

[EventKey<ClientAggregate>(1, "ClientDeletedDomainEvent")]
public class ClientDeletedDomainEvent(
     Guid aggregateId,
     string name,
     string lastName,
     string email,
     Address address,
     bool isActive,
     Instant createdAt,
     Guid createdBy,
     Instant? updatedAt,
     Guid? updatedBy,
     Guid? eventId = null,
     Instant? occurredAt = null,
     Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public string Name { get; } = name;
    public string LastName { get; } = lastName;
    public string Email { get; } = email;
    public Address Address { get; } = address;
    public bool IsActive { get; } = isActive;
    public Instant CreatedAt { get; } = createdAt;
    public Guid CreatedBy { get; } = createdBy;
    public Instant? UpdatedAt { get; } = updatedAt;
    public Guid? UpdatedBy { get; } = updatedBy;

    public static ClientDeletedDomainEvent Create(
        Guid aggregateId,
        string name,
        string lastName,
        string email,
        Address address,
        bool isActive,
        Instant createdAt,
        Guid createdBy,
        Instant? updatedAt,
        Guid? updatedBy
    )
    {
        return new ClientDeletedDomainEvent(aggregateId, name, lastName, email, address, isActive, createdAt, createdBy, updatedAt, updatedBy);
    }
}
