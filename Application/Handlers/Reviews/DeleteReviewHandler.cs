using Application.Abstractions.DataAccess;
using Application.Extensions;
using MediatR;
using static Application.Contracts.Review.DeleteReview;

namespace Application.Handlers.Reviews;

public class DeleteReviewHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public DeleteReviewHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.GetEntityAsync(request.ReviewId, cancellationToken);
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}