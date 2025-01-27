namespace Acme.Net.Microservice.Clients.Application.Subscription.Commands.InactivateClient;

public class InactiveClientCommandHandler(IMediator mediator, ISubscriptionRepository repository) : IRequestHandler<InactivateClientCommand>
{
    public async Task Handle(InactivateClientCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exist = await repository.ExistsAsync<SubscriptionAggregate>(request.Id, request.Tenant, cancellationToken);

        ApplicationGuard.IsTrue(exist, Errors.SuscriptionAlreadyIsCanceled);

        var suscription = SubscriptionAggregate.Create(request.Id, request.IdClient, request.IdProduct, request.StartDate, request.EndDate, request.Tenant, request.CreatedBy);

        await repository.CreateAsync(suscription, cancellationToken);

        await mediator.Send(new Client.Commands.InactivateClient.InactivateClientCommand(request.IdClient), cancellationToken);
    }
}