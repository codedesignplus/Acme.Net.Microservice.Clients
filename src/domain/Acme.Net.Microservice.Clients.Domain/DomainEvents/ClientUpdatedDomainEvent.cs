using Acme.Net.Microservice.Clients.Domain.ValueObjects;

namespace Acme.Net.Microservice.Clients.Domain.DomainEvents;

[EventKey<ClientAggregate>(1, "ClientUpdatedDomainEvent")]
public class ClientUpdatedDomainEvent(
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

    public static ClientUpdatedDomainEvent Create(
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
        return new ClientUpdatedDomainEvent(aggregateId, name, lastName, email, address, isActive, createdAt, createdBy, updatedAt, updatedBy);
    }
}