using CatchUpPlatform.API.Hr.Domain.Model.Aggregates;
using CatchUpPlatform.API.Hr.Domain.Repositories;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;


namespace CatchUpPlatform.API.Hr.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context)
: BaseRepository<Clients>(context), IClientRepository
{
    
}