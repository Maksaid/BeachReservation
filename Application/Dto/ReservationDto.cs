namespace Application.Dto;

public record ReservationDto(Guid ReservationId, UmbrellaDto Umbrella, DateTime DateFrom, DateTime DateTo,DateTime ReservationDate)
{
}