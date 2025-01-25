using System.Text.Json.Serialization;

namespace Acme.Net.Microservice.Clients.Domain.ValueObjects;

public sealed partial class Address
{
    [GeneratedRegex(@"^[a-zA-Z0-9\s,.'-]{3,}$")]
    private static partial Regex Regex();

    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string AddressValue { get; private set; }

    public Address()
    {
        this.Country = string.Empty;
        this.State = string.Empty;
        this.City = string.Empty;
        this.AddressValue = string.Empty;
    }

    [JsonConstructor]
    private Address(string country, string state, string city, string addressValue)
    {
        DomainGuard.IsNullOrEmpty(country, Errors.InvalidCountry);
        DomainGuard.IsNullOrEmpty(state, Errors.InvalidState);
        DomainGuard.IsNullOrEmpty(city, Errors.InvalidCity);
        DomainGuard.IsNullOrEmpty(addressValue, Errors.InvalidAddress);

        DomainGuard.IsFalse(Regex().IsMatch(addressValue), Errors.InvalidAddress);

        this.Country = country;
        this.State = state;
        this.City = city;
        this.AddressValue = addressValue;
    }

    public static Address Create(string country, string state, string city, string address)
    {
        return new Address(country, state, city, address);
    }

    public static Address Empty()
    {
        return new Address();
    }
}
