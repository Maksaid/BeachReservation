using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class UmbrellaMapping
{
    public static UmbrellaDto AsDto(this Umbrella umbrella)
        => new UmbrellaDto(umbrella.Id, umbrella.Number,umbrella.Index, umbrella.Beach.Id, umbrella.Reservations.MapReservations());

    
    private static List<ReservationShortDto> MapReservations(this List<Reservation> reservations) => reservations.Select(x => x.AsShortDto()).ToList();

}

