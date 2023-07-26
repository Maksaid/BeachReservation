using Application.Dto;
using MediatR;

namespace Application.Contracts.Beach;

public static class GetBeachesByLocation
{
    public record struct Command(string Country, string City, string Longitude, string Latitude) : IRequest<Response>;

    public record struct Response(List<BeachDto> BeachDtos);
}