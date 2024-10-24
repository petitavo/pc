using System.Net.Mime;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;
using CatchUpPlatform.API.News.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CatchUpPlatform.API.News.Interfaces.REST;

/// <summary>
/// Favorite Sources Controller 
/// </summary>
/// <param name="favoriteSourceCommandService">The <see cref="IFavoriteSourceCommandService"/> instance</param>
/// <param name="favoriteSourceQueryService">The <see cref="IFavoriteSourceQueryService"/> instance</param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Favorite Sources")]
public class FavoriteSourcesController(
    IFavoriteSourceCommandService favoriteSourceCommandService,
    IFavoriteSourceQueryService favoriteSourceQueryService
    ) : ControllerBase
{
    
    /// <summary>
    /// Create a favorite source 
    /// </summary>
    /// <param name="resource">The <see cref="CreateFavoriteSourceResource"/> resource</param>
    /// <returns>
    /// The <see cref="ActionResult"/> of the request containing the <see cref="FavoriteSourceResource"/> resource
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a favorite source",
        Description = "Create a favorite source with the specified news API key and source ID",
        OperationId = "CreateFavoriteSource")]
    [SwaggerResponse(StatusCodes.Status201Created, "The favorite source was created", typeof(FavoriteSourceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The favorite source could not be created")]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await favoriteSourceCommandService.Handle(createFavoriteSourceCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetFavoriteSourceById), new { id = result.Id },
            FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Get Favorite Source by ID 
    /// </summary>
    /// <param name="id">The Favorite Source ID generated by this API</param>
    /// <returns>
    /// The <see cref="ActionResult"/> of the request containing the <see cref="FavoriteSourceResource"/> resource for the given ID
    /// </returns>
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a favorite source by ID",
        Description = "Get a favorite source by the specified ID",
        OperationId = "GetFavoriteSourceById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The favorite source was found", typeof(FavoriteSourceResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The favorite source was not found")]
    public async Task<ActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    /// <summary>
    /// Get all favorite sources by News API Key 
    /// </summary>
    /// <param name="newsApiKey">
    /// The News API Key to get all favorite sources for
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/> of the request containing the <see cref="FavoriteSourceResource"/> resources for the given News API Key
    /// </returns>
    private async Task<ActionResult> GetAllFavoriteSourcesByNewsApiKey(string newsApiKey)
    {
        var getAllFavoriteSourcesByNewsApiKeyQuery = new GetAllFavoriteSourcesByNewsApiKeyQuery(newsApiKey);
        var result = await favoriteSourceQueryService.Handle(getAllFavoriteSourcesByNewsApiKeyQuery);
        var resources = 
            result.Select(FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Get Favorite Source by News API Key and Source ID 
    /// </summary>
    /// <param name="newsApiKey">
    /// The News API Key to get the favorite source for
    /// </param>
    /// <param name="sourceId">
    /// The Source ID to get the favorite source for
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/> of the request containing the <see cref="FavoriteSourceResource"/> resource for the given News API Key and Source ID
    /// </returns>
    private async Task<ActionResult> GetFavoriteSourceByNewsApiKeyAndSourceId(string newsApiKey, string sourceId)
    {
        var getFavoriteSourceByNewsApiKeyAndSourceIdQuery = 
            new GetFavoriteSourceByNewsApiKeyAndSourceIdQuery(newsApiKey, sourceId);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByNewsApiKeyAndSourceIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    /// <summary>
    /// Get favorite source(s) by News API Key and optionally by Source ID 
    /// </summary>
    /// <param name="newsApiKey">
    /// The News API Key to get the favorite source(s) for
    /// </param>
    /// <param name="sourceId">
    /// The Source ID to get the favorite source for
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/> of the request containing the <see cref="FavoriteSourceResource"/> resource(s) for the given News API Key and optionally Source ID.
    /// If Source ID is not provided, all favorite sources for the given News API Key will be returned.
    /// If no favorite sources are found, a 404 Not Found response will be returned.
    /// </returns>
    [SwaggerOperation(
        Summary = "Get favorite source(s) by News API Key and optionally by Source ID",
        Description = "Get favorite source(s) by the specified News API Key and optionally by the specified Source ID",
        OperationId = "GetFavoriteSourcesFromQuery")]
    [SwaggerResponse(200, "Returns the favorite source(s)")]
    [SwaggerResponse(404, "The favorite source(s) were not found")]
    [HttpGet]
    public async Task<ActionResult> GetFavoriteSourcesFromQuery(
        [FromQuery] string newsApiKey,
        [FromQuery] string sourceId = "")
    {
        return string.IsNullOrEmpty(sourceId)
            ? await GetAllFavoriteSourcesByNewsApiKey(newsApiKey)
            : await GetFavoriteSourceByNewsApiKeyAndSourceId(newsApiKey, sourceId);
    }
}