using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasOne(x => x.User).WithMany(x => x.Reservations);
        builder.HasOne(x=>x.Umbrella).WithMany(x=>x.Reservations);
        builder.HasKey(x =>x.Id);

    }
}