using CodeDesignPlus.Net.Core.Abstractions;
using Acme.Net.Microservice.Clients.Application.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Net.Microservice.Clients.Application
{
    public class Startup : IStartup
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            MapsterConfigClient.Configure();
        }
    }
}
