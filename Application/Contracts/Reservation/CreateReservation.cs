using Application.Dto;
using MediatR;

namespace Application.Contracts.Reservation;

public static class CreateReservation
{
    public record struct Command(Guid UmbrellaId, Guid UserId, DateTime DateFrom, DateTime DateTo, Guid BeachId) : IRequest<Response>;

    public record struct Response(ReservationDto ReservationDto);
}