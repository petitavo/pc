using CatchUpPlatform.API.Hr.Domain.Model.Aggregates;
using CatchUpPlatform.API.Hr.Domain.Model.Queries;

namespace CatchUpPlatform.API.Hr.Domain.Services;

/// <summary>
/// Client query service interface
/// </summary>
public interface IClientQueryService
{
    /// <summary>
    /// Handle get client by id query
    /// </summary>
    /// <param name="query">GetClientsByIdQuery query</param>
    /// <returns>
    /// The client if successful otherwise null
    /// </returns>
    /// <see cref="GetClientByIdQuery"/>
    Task<Clients?> Handle(GetClientByIdQuery query);
}