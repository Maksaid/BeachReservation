using Application.Abstractions.DataAccess;
using Application.Contracts.Beach;
using Application.Contracts.Users;
using Application.Dto;
using Application.Extensions;
using Application.Mapping;
using Domain.Entities;
using MediatR;
using static Application.Contracts.Review.AddReview;

namespace Application.Handlers.Reviews;

public class CreateReviewHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public CreateReviewHandler(IDatabaseContext context)
    {
        _context = context;
    }
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var author = await _context.Users.GetEntityAsync(request.OwnerId, cancellationToken);
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId, cancellationToken);
        
        
        var review = new Review(Guid.NewGuid(), request.Text, request.ReviewScore, author, beach);
        beach.Reviews.Add(review);
        author.Reviews.Add(review);
        await _context.Reviews.AddEntityAsync(review, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return new Response(review.AsDto());
    }
}