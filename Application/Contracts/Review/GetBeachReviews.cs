using Application.Dto;
using MediatR;

namespace Application.Contracts.Review;

public static class GetBeachReviews
{
    public record struct Command(Guid BeachId) : IRequest<Response>;

    public record struct Response(List<ReviewDto> ReviewDtos);
}