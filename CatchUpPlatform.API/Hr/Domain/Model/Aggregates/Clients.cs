using CatchUpPlatform.API.Hr.Domain.Model.Commands;

namespace CatchUpPlatform.API.Hr.Domain.Model.Aggregates;

///Clients Aggregate
/// <summary>
/// This class represents the Clients aggregate. It is used to store the information of the clients.
/// </summary>
public class Clients
{
    public int Id { get; private set; }
    public string PersonName { get; private set; }
    public string Dni { get; private set; }
    public string Email { get; private set; }
    public string BusinessName { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Ruc { get; private set; }

    protected Clients()
    {
        this.PersonName = string.Empty;
        this.Dni = string.Empty;
        this.Email = string.Empty;
        this.BusinessName = string.Empty;
        this.Phone = string.Empty;
        this.Address = string.Empty;
        this.Country = string.Empty;
        this.City = string.Empty;
        this.Ruc = string.Empty;
        
    }

    /// <summary>
    /// Constructor of the Clients aggregate
    /// </summary>
    /// <remarks>
    /// This constructor is the command handle for the CreateClientsSourceCommand.
    /// </remarks>
    /// <param name="command">The CreateClientsSourceCommand</param>
    public Clients(CreateClientsSourceCommand command)
    {
        this.PersonName = command.PersonName;
        this.Dni = command.Dni;
        this.Email = command.Email;
        this.BusinessName = command.BusinessName;
        this.Phone = command.Phone;
        this.Address = command.Address;
        this.Country = command.Country;
        this.City = command.City;
        this.Ruc = command.Ruc;
    }
    
}

