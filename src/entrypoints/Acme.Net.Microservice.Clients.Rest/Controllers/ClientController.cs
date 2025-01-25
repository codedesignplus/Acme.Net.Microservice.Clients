namespace Acme.Net.Microservice.Clients.Rest.Controllers;

/// <summary>
/// Controller class responsible for handling HTTP requests related to clients.
/// </summary>
/// <param name="mediator">Mediator instance for sending commands and queries.</param>
/// <param name="mapper">Mapper instance for mapping between DTOs and commands/queries.</param>
[Route("api/[controller]")]
[ApiController]
public class ClientController(IMediator mediator, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all clients.
    /// </summary>
    /// <param name="criteria">Criteria for filtering and sorting the clients.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of clients.</returns>
    [HttpGet]
    public async Task<IActionResult> GetClients([FromQuery] C.Criteria criteria, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllClientQuery(criteria), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get a client by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The client.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetClientByIdQuery(id), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Create a new client.
    /// </summary>
    /// <param name="data">Data for creating the client.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientDto data, CancellationToken cancellationToken)
    { 
        await mediator.Send(mapper.Map<CreateClientCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Update an existing client.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <param name="data">Data for updating the client.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(Guid id, [FromBody] UpdateClientDto data, CancellationToken cancellationToken)
    {
        data.Id = id;

        await mediator.Send(mapper.Map<UpdateClientCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete a client by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteClientCommand(id), cancellationToken);

        return NoContent();
    }
}
