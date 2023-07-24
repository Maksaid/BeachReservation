using Application.Abstractions.DataAccess;
using Application.Extensions;
using MediatR;
using static Application.Contracts.Reservation.DeleteReservation; 

namespace Application.Handlers.Reservations;

public class DeleteReservationHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public DeleteReservationHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var beach = await _context.Beaches.GetEntityAsync(request.ReservationId, cancellationToken);
        _context.Beaches.Remove(beach);
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}
