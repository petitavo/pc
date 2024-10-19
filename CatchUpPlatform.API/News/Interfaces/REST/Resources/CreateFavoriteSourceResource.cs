namespace CatchUpPlatform.API.News.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a favorite source. 
/// </summary>
/// <param name="NewsApiKey">The News API Key generated by the News provider</param>
/// <param name="SourceId">The News Source ID</param>
public record CreateFavoriteSourceResource(string NewsApiKey, string SourceId);