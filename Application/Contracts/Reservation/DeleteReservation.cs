using MediatR;

namespace Application.Contracts.Reservation;

public class DeleteReservation
{
    public record struct Command(Guid ReservationId) : IRequest;

}