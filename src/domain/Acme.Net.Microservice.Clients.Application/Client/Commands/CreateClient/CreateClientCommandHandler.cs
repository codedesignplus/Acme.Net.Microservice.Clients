namespace Acme.Net.Microservice.Clients.Application.Client.Commands.CreateClient;

public class CreateClientCommandHandler(IClientRepository repository, IUserContext user, IPubSub pubSub) 
    : IRequestHandler<CreateClientCommand>
{
    public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exist = await repository.ExistsAsync<ClientAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsTrue(exist, Errors.ClientAlreadyExists);

        var client = ClientAggregate.Create(request.Id, request.Name, request.LastName, request.Email, request.Address, user.IdUser, user.Tenant);

        await repository.CreateAsync(client, cancellationToken);

        await pubSub.PublishAsync(client.GetAndClearEvents(), cancellationToken);
    }
}