namespace Acme.Net.Microservice.Clients.Application;

public class Errors: IErrorCodes
{    
    public const string UnknownError = "200 : UnknownError";
    public const string InvalidRequest = "201 : Invalid Request";
    public const string ClientAlreadyExists = "202 : The client already exists";
    public const string ClientNotFound = "203 : The client was not found";
    public const string OrderNotFound = "204 : The order was not found";
    public const string OrderAlreadyExists = "205 : The order already exists";

    public const string SuscriptionAlreadyIsCanceled = "206 : The subscription is already canceled";
}
