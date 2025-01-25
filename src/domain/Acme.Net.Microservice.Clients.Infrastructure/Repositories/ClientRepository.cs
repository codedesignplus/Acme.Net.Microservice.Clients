namespace Acme.Net.Microservice.Clients.Infrastructure.Repositories;

public class ClientRepository(IServiceProvider serviceProvider, IOptions<MongoOptions> mongoOptions, ILogger<ClientRepository> logger) 
    : RepositoryBase(serviceProvider, mongoOptions, logger), IClientRepository
{
   
}