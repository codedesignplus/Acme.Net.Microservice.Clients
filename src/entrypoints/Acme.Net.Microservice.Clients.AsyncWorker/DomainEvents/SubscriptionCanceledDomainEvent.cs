using Acme.Net.Microservice.Clients.Domain.Enums;

namespace Acme.Net.Microservice.Clients.AsyncWorker.DomainEvents;

[EventKey<SubscriptionAggregate>(1, "SubscriptionCanceledDomainEvent", "ms-subscriptions")]
public class SubscriptionCanceledDomainEvent(
     Guid aggregateId,
     Guid idClient,
     Guid idProduct,
     SubscriptionStatus status,
     Instant startDate,
     Instant endDate,
     Guid tenant,
     Guid createdBy,
     Instant createdAt,
     Guid? updatedBy,
     Instant? updatedAt,
     Guid? eventId = null,
     Instant? occurredAt = null,
     Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public Guid IdClient { get; private set; } = idClient;
    public Guid IdProduct { get; private set; } = idProduct;
    public SubscriptionStatus Status { get; private set; } = status;
    public Instant StartDate { get; private set; } = startDate;
    public Instant EndDate { get; private set; } = endDate;
    public Guid Tenant { get; private set; } = tenant;
    public Guid CreatedBy { get; private set; } = createdBy;
    public Instant CreatedAt { get; private set; } = createdAt;
    public Guid? UpdatedBy { get; private set; } = updatedBy;
    public Instant? UpdatedAt { get; private set; } = updatedAt;
}
