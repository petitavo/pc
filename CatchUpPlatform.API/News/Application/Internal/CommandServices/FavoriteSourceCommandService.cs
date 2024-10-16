using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Commands;
using CatchUpPlatform.API.News.Domain.Repositories;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.Shared.Domain.Repositories;

namespace CatchUpPlatform.API.News.Application.Internal.CommandServices;

/// <summary>
/// Favorite source command service 
/// </summary>
/// <param name="favoriteSourceRepository">FavoriteSourceRepository instance</param>
/// <param name="unitOfWOrk">UnitOfWork instance</param>
public class FavoriteSourceCommandService(IFavoriteSourceRepository favoriteSourceRepository, IUnitOfWOrk unitOfWOrk)
    : IFavoriteSourceCommandService
{
    /// <inheritdoc cref="IFavoriteSourceCommandService.Handle"/>
    public async Task<FavoriteSource?> Handle(CreateFavoriteSourceCommand command)
    {
        var favoriteSource =
            await favoriteSourceRepository.FindByNewsApiKeyAndSourceIdAsync(command.NewsApiKey, command.SourceId);
        if (favoriteSource != null)
            throw new Exception("Favorite source with Source ID already exists for this News API Key");
        favoriteSource = new FavoriteSource(command);
        try
        {
            await favoriteSourceRepository.AddAsync(favoriteSource);
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return favoriteSource;
    }
}