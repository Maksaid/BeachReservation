using Application.Dto;
using MediatR;

namespace Application.Contracts.Review;

public static class AddReview
{
    public record struct Command(Guid BeachId, Guid OwnerId, int ReviewScore, string Text) : IRequest<Response>;

    public record struct Response(ReviewDto ReviewDto);
}