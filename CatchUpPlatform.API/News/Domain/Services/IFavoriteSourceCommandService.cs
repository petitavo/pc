using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Commands;

namespace CatchUpPlatform.API.News.Domain.Services;

/// <summary>
/// Favorite source command service interface
/// </summary>
public interface IFavoriteSourceCommandService
{
    /// <summary>
    /// Handle create favorite source command
    /// </summary>
    /// <param name="command">The CreateFavoriteSourceCommand command</param>
    /// <returns>
    /// The created favorite source if successful, otherwise null
    /// </returns>
    /// <see cref="CreateFavoriteSourceCommand"/>
    Task<FavoriteSource> Handle(CreateFavoriteSourceCommand command);
}