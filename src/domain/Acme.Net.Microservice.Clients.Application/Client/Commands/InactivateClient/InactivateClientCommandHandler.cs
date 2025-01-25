namespace Acme.Net.Microservice.Clients.Application.Client.Commands.InactivateClient;

public class InactivateClientCommandHandler(IClientRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<InactivateClientCommand>
{
    public async Task Handle(InactivateClientCommand request, CancellationToken cancellationToken)
    {        
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var client = await repository.FindAsync<ClientAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(client, Errors.ClientNotFound);

        client.Inactivate(user.IdUser);

        await repository.DeleteAsync<ClientAggregate>(client.Id, user.Tenant, cancellationToken);

        await pubSub.PublishAsync(client.GetAndClearEvents(), cancellationToken);
    }
}