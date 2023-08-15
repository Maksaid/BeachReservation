using Application.Abstractions.DataAccess;
using Domain.Entities;
using Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Beach> Beaches { get; private set; } = null!;

    public DbSet<Umbrella> Umbrellas { get; private set;} = null!;

    public DbSet<Review> Reviews { get; private set;} = null!;

    public DbSet<Reservation> Reservations { get; private set;} = null!;

    public DbSet<Image> Images { get; private set; } = null!;

    public DbSet<User> Users { get; private set;} = null!;
    public DbSet<Location> Locations { get; private set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BeachConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UmbrellaConfiguration());

        //TODO()
    }
}