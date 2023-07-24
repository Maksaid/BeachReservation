using Application;
using Application.Abstractions.DataAccess;
using Application.Abstractions.JwtAuth;
using Infrastructure.Authentication;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Presentation.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly));
        
        return collection;
    }
    public static IServiceCollection AddDataAccess(
        this IServiceCollection collection,
        Action<DbContextOptionsBuilder> configuration)
    {
        collection.AddDbContext<DatabaseContext>(configuration);
        collection.AddScoped<IDatabaseContext>(x => x.GetRequiredService<DatabaseContext>());

        return collection;
    }

    public static IServiceCollection AddJwtProvider(this IServiceCollection collection)
    {
        collection.AddScoped<JwtProvider>();
        collection.AddScoped<IJwtProvider>(x=>x.GetRequiredService<JwtProvider>());
        return collection;
    }
    /*public static IServiceCollection AddJsoServiceCollection(
        this IServiceCollection collection)
    {
        collection.Add
        return collection;
    }*/
}