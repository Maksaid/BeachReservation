using Domain.Entities;

namespace Domain.Exceptions;

public class ReservationException : DomainException
{
    private ReservationException(string? message) : base(message)
    {
    }

    public static ReservationException ReservationTimeOverlap(Reservation reservation) =>
        new ReservationException($"dates from {reservation.ReservationStart} to {reservation.ReservationEnd} have overlap with over reservations on umbrella {reservation.Umbrella.Id}");
}