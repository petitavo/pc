using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatform.API.News.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a <see cref="FavoriteSourceResource"/> from a <see cref="FavoriteSource"/>. 
/// </summary>
public static class FavoriteSourceResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a <see cref="FavoriteSource"/> to a <see cref="FavoriteSourceResource"/>. 
    /// </summary>
    /// <param name="entity">The <see cref="FavoriteSource"/> entity</param>
    /// <returns>
    /// A <see cref="FavoriteSourceResource"/> resource. 
    /// </returns>
    public static FavoriteSourceResource ToResourceFromEntity(FavoriteSource entity)
    {
        return new FavoriteSourceResource(entity.Id, entity.NewsApiKey, entity.SourceId);
    }
    
}