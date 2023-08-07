using Application.Abstractions.DataAccess;
using Application.Exceptions;
using Application.Extensions;
using Application.Mapping;
using Domain.Entities;
using static Application.Contracts.Reservation.CreateReservation;
using MediatR;

namespace Application.Handlers.Reservations;

public class CreateReservationHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateReservationHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.GetEntityAsync(request.UserId, cancellationToken);
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId, cancellationToken);
        var umbrella = beach.Umbrellas.Find(x => x.Id == request.UmbrellaId);
        if (umbrella is null)
            throw new NotFoundException($"umbrella with id: {request.UmbrellaId} was not found");

        var reservation = new Reservation(Guid.NewGuid(),request.DateFrom, request.DateTo,user, umbrella);
            user.Reservations.Add(reservation);
        umbrella.AddReservation(reservation);

        await _context.Reservations.AddEntityAsync(reservation, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(reservation.AsDto());
    }
}
