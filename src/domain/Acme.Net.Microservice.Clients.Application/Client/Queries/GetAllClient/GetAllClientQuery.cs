using CodeDesignPlus.Net.Core.Abstractions.Models.Criteria;

namespace Acme.Net.Microservice.Clients.Application.Client.Queries.GetAllClient;

public record GetAllClientQuery(Criteria Criteria) : IRequest<List<ClientDto>>;
