using Application.Abstractions.DataAccess;
using Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Beach.GetAllBeaches;

namespace Application.Handlers.Beaches;

public class GetAllBeachesHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public GetAllBeachesHandler(IDatabaseContext context)
    {
        _context = context;
    }
    /*
     * returns List<BeachDto> of sorted by AverageScore Beaches
     */
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beaches = await _context.Beaches.ToListAsync(cancellationToken);
        var sortedBeaches = beaches.OrderByDescending(x => x.AverageScore);
        return new Response(sortedBeaches.Select(x => x.AsShortDto()).ToList());
    }
}