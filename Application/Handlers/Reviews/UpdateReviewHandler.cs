using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using static Application.Contracts.Review.UpdateReview;
using MediatR;

namespace Application.Handlers.Reviews;

public class UpdateReviewHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public UpdateReviewHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.GetEntityAsync(request.ReviewId, cancellationToken);
        review.Text = request.Text;
        review.Score = request.NewScore;
        await _context.SaveChangesAsync(cancellationToken);
        return new Response(review.AsDto());
    }
}