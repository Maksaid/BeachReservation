using Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Extensions;

public static class DbSetExtensions
{
    public static async Task<T> GetEntityAsync<T>(this DbSet<T> set, Guid id, CancellationToken cancellationToken)
        where T : class
    {
        var entity = await set.FindAsync(new object[] { id }, cancellationToken);

        if (entity is null)
            throw EntityNotFoundException<T>.Create(id);

        return entity;
    }

    public static async Task AddEntityAsync<T>(this DbSet<T> set, T entity, CancellationToken cancellationToken)
        where T : class
    {
        var alreadyExists= set.ToList().Contains(entity);
       // var alreadyExists = await set.ContainsAsync(entity, cancellationToken);

        if (alreadyExists)
            throw EntityAlreadyExistException<T>.Create(entity);

        await set.AddAsync(entity, cancellationToken);
    }
}