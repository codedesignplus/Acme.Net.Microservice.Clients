namespace Acme.Net.Microservice.Clients.Application.Client.DataTransferObjects;

public class ClientDto: IDtoBase
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
}