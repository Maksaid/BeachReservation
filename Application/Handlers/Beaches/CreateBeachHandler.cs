using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Entities;
using MediatR;
using static Application.Contracts.Beach.CreateBeach;

namespace Application.Handlers.Beaches;

internal class CreateBeachHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateBeachHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {

        var owner = await _context.Users.GetEntityAsync(request.CurrentUserId, cancellationToken);
        var beach = new Beach(Guid.NewGuid(), request.Name, request.Description, request.ColsCount, request.RowsCount,owner,new Location(request.Country, request.City, request.Longitude, request.Latitude));
        owner.Beaches.Add(beach);
        await _context.Beaches.AddEntityAsync(beach,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(beach.AsDto());
    }
}