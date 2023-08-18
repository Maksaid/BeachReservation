namespace Application.Dto;

public record ReviewDto(Guid ReviewId, string Text, int ReviewScore, Guid AuthorId, string AuthorName, Guid BeachId)
{
}