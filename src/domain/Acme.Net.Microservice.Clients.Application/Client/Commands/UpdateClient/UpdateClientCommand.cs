namespace Acme.Net.Microservice.Clients.Application.Client.Commands.UpdateClient;

[DtoGenerator]
public record UpdateClientCommand(Guid Id, string Name, string LastName, string Email, Address Address) : IRequest;

public class Validator : AbstractValidator<UpdateClientCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.LastName).NotEmpty().NotNull();
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x => x.Address)
            .NotNull()
            .DependentRules(() =>
            {
                RuleFor(x => x.Address.Country).NotEmpty().NotNull();
                RuleFor(x => x.Address.State).NotEmpty().NotNull();
                RuleFor(x => x.Address.City).NotEmpty().NotNull();
                RuleFor(x => x.Address.AddressValue).NotEmpty().NotNull();
            });
    }
}
