using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class BeachMapping
{
    public static BeachDto AsDto(this Beach beach)
    {
        return new BeachDto(beach.Name,beach.Id, beach.Description, beach.Owner.AsDto(), beach.ColumnsCount, beach.RowsCount,MapUmbrellas(beach.Umbrellas));
    }

    private static List<UmbrellaDto> MapUmbrellas(List<Umbrella> umbrellas) => umbrellas.Select(x => x.AsDto()).ToList();
}