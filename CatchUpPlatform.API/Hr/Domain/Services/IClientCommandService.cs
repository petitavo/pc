using CatchUpPlatform.API.Hr.Domain.Model.Aggregates;
using CatchUpPlatform.API.Hr.Domain.Model.Commands;


namespace CatchUpPlatform.API.Hr.Domain.Services;

/// <summary>
/// Client command service interface
/// </summary>
public interface IClientCommandService
{
    /// <summary>
    /// Handle create client command
    /// </summary>
    /// <param name="command">The CreateClientsSourceCommand</param>
    /// <returns>
    /// The created client if successful otherwise null
    /// </returns>
    /// <see cref="CreateClientsSourceCommand"/>
    Task<Clients?> Handle(CreateClientsSourceCommand command);
}   