using CatchUpPlatform.API.News.Domain.Model.Commands;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatform.API.News.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a <see cref="CreateFavoriteSourceCommand"/> from a <see cref="CreateFavoriteSourceResource"/>. 
/// </summary>
public static class CreateFavoriteSourceCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a <see cref="CreateFavoriteSourceResource"/> to a <see cref="CreateFavoriteSourceCommand"/>. 
    /// </summary>
    /// <param name="resource">The <see cref="CreateFavoriteSourceResource"/> resource</param>
    /// <returns>
    /// A <see cref="CreateFavoriteSourceCommand"/> command. 
    /// </returns>
    public static CreateFavoriteSourceCommand ToCommandFromResource(CreateFavoriteSourceResource resource)
    {
        return new CreateFavoriteSourceCommand(resource.NewsApiKey, resource.SourceId);
    }
}