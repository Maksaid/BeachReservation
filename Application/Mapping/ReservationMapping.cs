using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class ReservationMapping
{
    public static ReservationDto AsDto(this Reservation reservation)
        => new ReservationDto(reservation.Id, reservation.Umbrella.AsDto(), reservation.ReservationStart,
            reservation.ReservationEnd, reservation.DateOfReservation);
    public static ReservationShortDto AsShortDto(this Reservation reservation)
        => new ReservationShortDto(reservation.Id,  reservation.ReservationStart,
            reservation.ReservationEnd);
}