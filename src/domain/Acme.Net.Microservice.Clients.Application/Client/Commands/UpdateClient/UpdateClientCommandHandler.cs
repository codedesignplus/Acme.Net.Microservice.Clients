namespace Acme.Net.Microservice.Clients.Application.Client.Commands.UpdateClient;

public class UpdateClientCommandHandler(IClientRepository repository, IUserContext user, IPubSub pubSub)
    : IRequestHandler<UpdateClientCommand>
{
    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var client = await repository.FindAsync<ClientAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(client, Errors.ClientNotFound);

        var address = Address.Create(request.Address.Country, request.Address.State, request.Address.City, request.Address.AddressValue);

        client.Update(request.Name, request.LastName, request.Email, address, user.IdUser);

        await repository.UpdateAsync(client, cancellationToken);

        await pubSub.PublishAsync(client.GetAndClearEvents(), cancellationToken);
    }
}