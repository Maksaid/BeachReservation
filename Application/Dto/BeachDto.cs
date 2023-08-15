using Domain.Entities;

namespace Application.Dto;

public record BeachDto(string BeachName, Guid Id, string BeachDescription, int BeachAverageScore, UserDto BeachOwner,
    int BeachColumnsCount,
    int BeachRowsCount, List<UmbrellaDto> Umbrellas, string Country, string City, List<Image> Images)
{
}