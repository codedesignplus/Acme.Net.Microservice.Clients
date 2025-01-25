namespace Acme.Net.Microservice.Clients.Application.Client.Commands.DeleteClient;

[DtoGenerator]
public record DeleteClientCommand(Guid Id) : IRequest;

public class Validator : AbstractValidator<DeleteClientCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
