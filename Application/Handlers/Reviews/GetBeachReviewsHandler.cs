using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Review.GetBeachReviews;

namespace Application.Handlers.Reviews;

public class GetBeachReviewsHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public GetBeachReviewsHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId, cancellationToken);
        var reviews = beach.Reviews;
        return new Response(reviews.Select(x => x.AsDto()).ToList());
    }
}