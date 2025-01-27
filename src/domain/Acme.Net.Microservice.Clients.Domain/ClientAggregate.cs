using Acme.Net.Microservice.Clients.Domain.ValueObjects;

namespace Acme.Net.Microservice.Clients.Domain;

public class ClientAggregate(Guid id) : AggregateRoot(id)
{
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Address Address { get; private set; } = Address.Empty();

    private ClientAggregate(Guid id, string name, string lastName, string email, Address address, Guid createdBy, Guid tenant)
        : this(id)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Email = email;
        this.Address = address;
        this.IsActive = true;
        this.CreatedBy = createdBy;
        this.CreatedAt = SystemClock.Instance.GetCurrentInstant();
        this.Tenant = tenant;

        this.AddEvent(ClientCreatedDomainEvent.Create(
            this.Id,
            this.Name,
            this.LastName,
            this.Email,
            this.Address,
            this.IsActive,
            this.CreatedAt,
            this.CreatedBy,
            this.Tenant
        ));
    }

    public static ClientAggregate Create(Guid id, string name, string lastName, string email, Address address, Guid createdBy, Guid tenant)
    {
        DomainGuard.IsNullOrEmpty(name, Errors.ClientNameIsRequired);
        DomainGuard.IsNullOrEmpty(lastName, Errors.ClientLastNameIsRequired);
        DomainGuard.IsNull(address, Errors.ClientAddressIsRequired);
        DomainGuard.IsNullOrEmpty(email, Errors.ClientEmailIsRequired);
        DomainGuard.GuidIsEmpty(id, Errors.InvalidAggregateId);
        DomainGuard.GuidIsEmpty(createdBy, Errors.InvalidCreatedBy);
        DomainGuard.GuidIsEmpty(tenant, Errors.InvalidTenant);

        return new ClientAggregate(id, name, lastName, email, address, createdBy, tenant);
    }

    public void Update(string name, string lastName, string email, Address address, Guid updatedBy)
    {
        DomainGuard.IsNullOrEmpty(name, Errors.ClientNameIsRequired);
        DomainGuard.IsNullOrEmpty(lastName, Errors.ClientLastNameIsRequired);
        DomainGuard.IsNull(address, Errors.ClientAddressIsRequired);
        DomainGuard.IsNullOrEmpty(email, Errors.ClientEmailIsRequired);
        DomainGuard.GuidIsEmpty(updatedBy, Errors.InvalidCreatedBy);

        this.Name = name;
        this.LastName = lastName;
        this.Email = email;
        this.Address = address;
        this.UpdatedBy = updatedBy;
        this.UpdatedAt = SystemClock.Instance.GetCurrentInstant();

        this.AddEvent(ClientUpdatedDomainEvent.Create(
            Id,
            name,
            lastName,
            email,
            address,
            IsActive,
            CreatedAt,
            CreatedBy,
            UpdatedAt,
            UpdatedBy
        ));
    }

    public void Delete(Guid updatedBy)
    {
        DomainGuard.GuidIsEmpty(updatedBy, Errors.InvalidCreatedBy);

        this.IsActive = false;
        this.UpdatedBy = updatedBy;
        this.UpdatedAt = SystemClock.Instance.GetCurrentInstant();

        this.AddEvent(ClientDeletedDomainEvent.Create(
            Id,
            Name,
            LastName,
            Email,
            Address,
            IsActive,
            CreatedAt,
            CreatedBy,
            UpdatedAt,
            UpdatedBy
        ));
    }

    public void Inactivate()
    {
        this.IsActive = false;
        this.UpdatedAt = SystemClock.Instance.GetCurrentInstant();

        this.AddEvent(ClientInactivatedDomainEvent.Create(Id, IsActive, UpdatedAt, UpdatedBy));
    }
}
