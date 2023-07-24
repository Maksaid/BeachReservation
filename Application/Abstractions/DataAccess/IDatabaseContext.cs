﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IDatabaseContext
{
    DbSet<Beach> Beaches { get; }
    DbSet<Umbrella> Umbrellas { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken token = default);
}