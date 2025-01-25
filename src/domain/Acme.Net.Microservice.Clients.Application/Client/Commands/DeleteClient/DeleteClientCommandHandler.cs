namespace Acme.Net.Microservice.Clients.Application.Client.Commands.DeleteClient;

public class DeleteClientCommandHandler(IClientRepository repository, IUserContext user, IPubSub pubSub) 
    : IRequestHandler<DeleteClientCommand>
{
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var client = await repository.FindAsync<ClientAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(client, Errors.ClientNotFound);

        client.Delete(user.IdUser);

        await repository.DeleteAsync<ClientAggregate>(client.Id, user.Tenant, cancellationToken);

        await pubSub.PublishAsync(client.GetAndClearEvents(), cancellationToken);
    }
}