namespace Acme.Net.Microservice.Clients.Infrastructure.Repositories;

public class SubscriptionRepository(IServiceProvider serviceProvider, IOptions<MongoOptions> mongoOptions, ILogger<SubscriptionRepository> logger) 
    : RepositoryBase(serviceProvider, mongoOptions, logger), ISubscriptionRepository
{
   
}