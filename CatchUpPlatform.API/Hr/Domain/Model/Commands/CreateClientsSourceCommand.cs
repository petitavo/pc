namespace CatchUpPlatform.API.Hr.Domain.Model.Commands;

public record CreateClientsSourceCommand(string PersonName, string Dni, string Email, string BusinessName, string Phone, string Address, string Country, string City, string Ruc);
