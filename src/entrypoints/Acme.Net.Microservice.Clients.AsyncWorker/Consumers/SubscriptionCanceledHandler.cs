using Acme.Net.Microservice.Clients.AsyncWorker.DomainEvents;
using MediatR;

namespace Acme.Net.Microservice.Clients.AsyncWorker.Consumers;

[QueueName("Subscription", "inactive_client")]
public class SubscriptionCanceledHandler(ILogger<SubscriptionCanceledHandler> logger, IMediator mediator) : IEventHandler<SubscriptionCanceledDomainEvent>
{
    public Task HandleAsync(SubscriptionCanceledDomainEvent data, CancellationToken token)
    {
        logger.LogInformation("SubscriptionCanceledDomainEvent Recived, {Json}", JsonSerializer.Serialize(data));

        mediator.Send(new Application.Subscription.Commands.InactivateClient.InactivateClientCommand(data.AggregateId, data.IdClient, data.IdProduct, data.StartDate, data.EndDate, data.CreatedBy, data.Tenant), token);

        return Task.CompletedTask;
    }
}
