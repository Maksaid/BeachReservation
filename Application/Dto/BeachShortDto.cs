namespace Application.Dto;

public record BeachShortDto(string BeachName, Guid Id, string BeachDescription, int BeachAverageScore,
    int BeachColumnsCount,
    int BeachRowsCount, string Country, string City)
{
}