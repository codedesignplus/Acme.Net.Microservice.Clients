namespace Acme.Net.Microservice.Clients.Application.Client.Queries.GetClientById;

public class GetClientByIdQueryHandler(IClientRepository repository, IMapper mapper, ICacheManager cacheManager, IUserContext user) 
    : IRequestHandler<GetClientByIdQuery, ClientDto>
{
    public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exists = await cacheManager.ExistsAsync(request.Id.ToString());

        if (exists)
            return await cacheManager.GetAsync<ClientDto>(request.Id.ToString());

        var client = await repository.FindAsync<ClientAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(client, Errors.ClientNotFound);

        await cacheManager.SetAsync(request.Id.ToString(), mapper.Map<ClientDto>(client));

        return mapper.Map<ClientDto>(client);
    }
}
