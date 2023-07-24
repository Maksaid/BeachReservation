using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

public class BeachConfiguration : IEntityTypeConfiguration<Beach>
{
    public void Configure(EntityTypeBuilder<Beach> builder)
    {
        builder.HasMany(x=>x.Reviews).WithOne(x=>x.Beach);
        builder.HasMany(x => x.Umbrellas).WithOne(x=>x.Beach);
        builder.HasOne(x => x.Owner).WithMany(x=>x.Beaches);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description);
        builder.Property(x => x.Name);
    }
}