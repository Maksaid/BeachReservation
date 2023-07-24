using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

public class UmbrellaConfiguration : IEntityTypeConfiguration<Umbrella>
{
    public void Configure(EntityTypeBuilder<Umbrella> builder)
    {
        builder.HasOne(x=>x.Beach).WithMany(x => x.Umbrellas);
        builder.HasMany(x=>x.Reservations).WithOne(x => x.Umbrella);
        builder.HasKey(x => x.Id);

    }
}