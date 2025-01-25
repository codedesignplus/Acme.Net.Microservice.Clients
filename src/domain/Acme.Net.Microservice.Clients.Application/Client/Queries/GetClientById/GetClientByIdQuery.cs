namespace Acme.Net.Microservice.Clients.Application.Client.Queries.GetClientById;

public record GetClientByIdQuery(Guid Id) : IRequest<ClientDto>;

