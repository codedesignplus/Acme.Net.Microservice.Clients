namespace Acme.Net.Microservice.Clients.gRpc.Core.Mapster;

public static class MapsterConfig
{
    public static void Configure() {
         TypeAdapterConfig<ClientDto, ClientResponse>.NewConfig();
     }
}