namespace Presentation.Models;

public record AddReviewModel(Guid BeachId, int Score, string Text)
{
}