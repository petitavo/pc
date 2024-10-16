using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Repositories;
using CatchUpPlatform.API.News.Domain.Services;

namespace CatchUpPlatform.API.News.Application.Internal.QueryServices;

/// <summary>
/// Query service for favorite sources. 
/// </summary>
/// <param name="favoriteSourceRepository">FavoriteSourceRepository instance</param>
public class FavoriteSourceQueryService(IFavoriteSourceRepository favoriteSourceRepository) : IFavoriteSourceQueryService
{
    /// <inheritdoc cref="IFavoriteSourceQueryService.Handle(GetAllFavoriteSourcesByNewsApiKeyQuery)"/>
    public async Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query)
    {
        return await favoriteSourceRepository.FindByNewsApiKeyAsync(query.NewsApiKey);
    }

    /// <inheritdoc cref="IFavoriteSourceQueryService.Handle(GetFavoriteSourceByIdQuery)"/>
    public async Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery query)
    {
        return await favoriteSourceRepository.FindByIdAsync(query.Id);
    }

    /// <inheritdoc cref="IFavoriteSourceQueryService.Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery)"/>
    public async Task<FavoriteSource?> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query)
    {
        return await favoriteSourceRepository.FindByNewsApiKeyAndSourceIdAsync(query.NewsApiKey, query.SourceId);
    }
}