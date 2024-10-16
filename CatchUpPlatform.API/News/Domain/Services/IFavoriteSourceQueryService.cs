using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Queries;

namespace CatchUpPlatform.API.News.Domain.Services;

/// <summary>
/// Favorite source query service interface 
/// </summary>
public interface IFavoriteSourceQueryService
{
    /// <summary>
    /// Handle get all favorite sources by news api key query. 
    /// </summary>
    /// <param name="query">GetAllFavoriteSourcesByNewsApiKeyQuery query</param>
    /// <returns>
    /// The list of favorite sources if successful, otherwise null. 
    /// </returns>
    /// See <see cref="GetAllFavoriteSourcesByNewsApiKeyQuery"/>
    Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query);
    
    /// <summary>
    /// Handle get favorite source by id query. 
    /// </summary>
    /// <param name="query">GetFavoriteSourceByIdQuery query</param>
    /// <returns>
    /// The favorite source if successful, otherwise null. 
    /// </returns>
    /// See <see cref="GetFavoriteSourceByIdQuery"/> 
    Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery query);
    
    /// <summary>
    /// Handle get favorite source by news api key and source id query. 
    /// </summary>
    /// <param name="query">GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query</param>
    /// <returns>
    /// The favorite source if successful, otherwise null.
    /// </returns>
    /// See <see cref="GetFavoriteSourceByNewsApiKeyAndSourceIdQuery"/> 
    Task<FavoriteSource?> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query);
}