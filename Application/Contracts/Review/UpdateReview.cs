using Application.Dto;
using MediatR;

namespace Application.Contracts.Review;

public static class UpdateReview
{
    public record struct Command(Guid ReviewId,int NewScore, string Text) : IRequest<Response>;

    public record struct Response(ReviewDto ReviewDto);
}