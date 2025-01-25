using Acme.Net.Microservice.Clients.Application.Client.Commands.CreateClient;
using Acme.Net.Microservice.Clients.Application.Client.Commands.UpdateClient;
using CodeDesignPlus.Microservice.Api.Dtos;

namespace Acme.Net.Microservice.Clients.Application.Setup;

public static class MapsterConfigClient
{
     public static void Configure()
    {
        TypeAdapterConfig<CreateClientDto, CreateClientCommand>
            .NewConfig()
            .ConstructUsing(src => new CreateClientCommand(src.Id, src.Name, src.LastName, src.Email, Address.Create(src.Address.Country, src.Address.State, src.Address.City, src.Address.AddressValue)));

        TypeAdapterConfig<UpdateClientDto, UpdateClientCommand>
            .NewConfig()
            .ConstructUsing(src => new UpdateClientCommand(src.Id, src.Name, src.LastName, src.Email, Address.Create(src.Address.Country, src.Address.State, src.Address.City, src.Address.AddressValue)));

        TypeAdapterConfig<ClientAggregate, ClientDto>
            .NewConfig()
            .Map(dest => dest.Address, src => Address.Create(src.Address.Country, src.Address.State, src.Address.City, src.Address.AddressValue));
    }
}
