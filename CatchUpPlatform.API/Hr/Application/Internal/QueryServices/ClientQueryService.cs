using CatchUpPlatform.API.Hr.Domain.Model.Aggregates;
using CatchUpPlatform.API.Hr.Domain.Model.Queries;
using CatchUpPlatform.API.Hr.Domain.Repositories;
using CatchUpPlatform.API.Hr.Domain.Services;

namespace CatchUpPlatform.API.Hr.Application.Internal.QueryServices;

/// <summary>
/// Query service for clients
/// </summary>
/// <param name="clientRepository">ClientRepository instance</param>
public class ClientQueryService(IClientRepository clientRepository) : IClientQueryService
{
    /// <inheritdoc cref="IClientQueryService.Handle(GetClientByIdQuery)"/>
    public async Task<Clients?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.Id);
    }
}