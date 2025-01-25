namespace Acme.Net.Microservice.Clients.Application.Client.Commands.InactivateClient;

public record InactivateClientCommand(Guid Id) : IRequest;

public class Validator : AbstractValidator<InactivateClientCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
