namespace Acme.Net.Microservice.Clients.Application.Client.Queries.GetAllClient;

public class GetAllClientQueryHandler(IClientRepository repository, IMapper mapper, IUserContext user) 
    : IRequestHandler<GetAllClientQuery, List<ClientDto>>
{
    public async Task<List<ClientDto>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var clients = await repository.MatchingAsync<ClientAggregate>(request.Criteria, user.Tenant, cancellationToken);

        return mapper.Map<List<ClientDto>>(clients);
    }
}
