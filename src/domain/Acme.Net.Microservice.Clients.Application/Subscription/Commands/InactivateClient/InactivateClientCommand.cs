namespace Acme.Net.Microservice.Clients.Application.Subscription.Commands.InactivateClient;

public record InactivatedClientCommand(Guid Id, Guid IdClient, Guid IdProduct, Instant StartDate, Instant EndDate, Guid CreatedBy, Guid Tenant) : IRequest;

public class Validator : AbstractValidator<InactivatedClientCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.IdClient).NotEmpty().NotNull();
        RuleFor(x => x.IdProduct).NotEmpty().NotNull();
        RuleFor(x => x.StartDate).NotEmpty().NotNull();
        RuleFor(x => x.EndDate).NotEmpty().NotNull();
        RuleFor(x => x.CreatedBy).NotEmpty().NotNull();
        RuleFor(x => x.Tenant).NotEmpty().NotNull();
    }
}
