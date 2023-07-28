using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class BeachMapping
{
    public static BeachDto AsDto(this Beach beach)
    {
        return new BeachDto(beach.Name,beach.Id, beach.Description,beach.AverageScore, beach.Owner.AsDto(), beach.ColumnsCount, beach.RowsCount,MapUmbrellas(beach.Umbrellas));
    }
    public static BeachShortDto AsShortDto(this Beach beach)
    {
        return new BeachShortDto(beach.Name,beach.Id, beach.Description,beach.AverageScore, beach.ColumnsCount, beach.RowsCount,beach.Location.Country,beach.Location.City);
    }

    private static List<UmbrellaDto> MapUmbrellas(List<Umbrella> umbrellas) => umbrellas.Select(x => x.AsDto()).ToList();
}