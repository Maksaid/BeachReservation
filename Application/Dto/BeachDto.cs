using Domain.Entities;

namespace Application.Dto;

public record BeachDto(string BeachName,Guid Id, string BeachDescription, UserDto BeachOwner, int BeachColumnsCount,
    int BeachRowsCount, List<UmbrellaDto> Umbrellas)
{
}