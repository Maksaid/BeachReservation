using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x=>x.Beaches).WithOne(x => x.Owner);
        builder.HasMany(x=>x.Reviews).WithOne(x => x.Author);
        builder.HasMany(x => x.Reservations).WithOne(x => x.User);
        builder.HasKey(x => x.Id);

    }
}