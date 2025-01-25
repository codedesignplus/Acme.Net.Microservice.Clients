using Acme.Net.Microservice.Clients.Application.Client.Queries.GetClientById;

namespace Acme.Net.Microservice.Clients.gRpc.Services;

public class ClientService(IMediator mediator, IMapper mapper) : Client.ClientBase
{
    public override async Task GetClient(IAsyncStreamReader<GetClientRequest> requestStream, IServerStreamWriter<ClientResponse> responseStream, ServerCallContext context)
    {
        await foreach (var request in requestStream.ReadAllAsync())
        {
            if (!Guid.TryParse(request.Id, out Guid id))
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Id"));

            var result = await mediator.Send(new GetClientByIdQuery(id), context.CancellationToken);

            var response = mapper.Map<ClientDto, ClientResponse>(result);

            await responseStream.WriteAsync(response);
        }
    }
}