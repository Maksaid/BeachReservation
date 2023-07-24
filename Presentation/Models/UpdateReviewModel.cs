namespace Presentation.Models;

public record UpdateReviewModel(Guid ReviewId, int NewReviewScore, string NewText)
{
    
}