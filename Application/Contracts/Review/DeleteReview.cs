using MediatR;

namespace Application.Contracts.Review;

public static class DeleteReview
{
    public record struct Command(Guid ReviewId) : IRequest;

}