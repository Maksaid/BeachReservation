namespace Application.Dto;

public record UmbrellaDto(Guid Id, int Number, int Index, Guid BeachId, List<ReservationShortDto> Reservations)
{
}