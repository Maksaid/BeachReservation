using Application.Abstractions.DataAccess;
using Application.Dto;
using Application.Exceptions;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Users.GetUserDetails;

namespace Application.Handlers.Users;

public class GetUserDetailsHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public GetUserDetailsHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.GetEntityAsync(request.Id, cancellationToken);
        var reservations = await _context.Reservations.Where(reservation => reservation.User.Id == request.Id)
            .ToListAsync(cancellationToken);
        var reviews = await _context.Reviews.Where(review => review.Author.Id == request.Id)
            .ToListAsync(cancellationToken);
        var beaches = await _context.Beaches.Where(beach => beach.Owner.Id == request.Id).ToListAsync(cancellationToken);

        return new Response(user.AsDetailsDto(beaches,reviews,reservations));
    }
}