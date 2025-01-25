namespace Acme.Net.Microservice.Clients.Domain;

public class Errors: IErrorCodes
{    
    
    public const string UnknownError = "100 : UnknownError";
    public const string InvalidCountry = "101 : InvalidCountry";
    public const string InvalidState = "102 : InvalidState";
    public const string InvalidCity = "103 : InvalidCity";
    public const string InvalidAddress = "104 : InvalidAddress";
    public const string ClientAddressIsRequired = "105 : ClientAddressIsRequired";
    public const string ClientNameIsRequired = "106 : ClientNameIsRequired";
    public const string ClientEmailIsRequired = "107 : ClientEmailIsRequired";
    public const string ClientLastNameIsRequired = "108 : ClientLastNameIsRequired";
    public const string InvalidAggregateId = "109 : InvalidAggregateId";
    public const string InvalidCreatedBy = "110 : InvalidCreatedBy";
    public const string ProductIsRequired = "111 : The product is required";
    public const string InvalidTenant = "112 : The tenant is required";
    public const string InvalidCreatedAt = "113 : The created at is required";

    public static string InvalidIdSuscription = "114 : The id suscription is required";
    public static string InvalidIdClient = "115 : The id client is required";
    public static string InvalidIdProduct = "116 : The id product is required";
    public static string InvalidStartDate = "117 : The start date is required";
    public static string InvalidEndDate = "118 : The end date is required";
    public static string StartDateGreaterThanEndDate = "119 : The start date is greater than the end date";
}
