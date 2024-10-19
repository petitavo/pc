using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;


public partial class FavoriteSource : IEntityWithCreatedUpdatedDate
{
    // The CreatedDate and UpdatedDate properties are used to store the date and time when the entity was created and updated.
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}