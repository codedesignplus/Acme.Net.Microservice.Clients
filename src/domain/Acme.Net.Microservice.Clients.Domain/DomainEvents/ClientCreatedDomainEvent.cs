using Acme.Net.Microservice.Clients.Domain.ValueObjects;

namespace Acme.Net.Microservice.Clients.Domain.DomainEvents;

[EventKey<ClientAggregate>(1, "ClientCreatedDomainEvent")]
public class ClientCreatedDomainEvent(
     Guid aggregateId,
     string name,
     string lastName,
     string email,
     Address address,
     bool isActive,
     Instant createdAt,
     Guid createdBy,
     Guid tenant,
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
    public Guid Tenant { get; } = tenant;

    public static ClientCreatedDomainEvent Create(
        Guid aggregateId,
        string name,
        string lastName,
        string email,
        Address address,
        bool isActive,
        Instant createdAt,
        Guid createdBy,
        Guid tenant
    )
    {
        return new ClientCreatedDomainEvent(aggregateId, name, lastName, email, address, isActive, createdAt, createdBy, tenant);
    }
}
