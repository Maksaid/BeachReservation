using Application.Abstractions.DataAccess;
using Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Beach.GetBeachesByLocation;

namespace Application.Handlers.Beaches;


public class GetBeachByLocationHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public GetBeachByLocationHandler(IDatabaseContext context)
    {
        _context = context;
    }
    /*
     * returns List<BeachDto> of filtered by location and sorted by AverageScore and location Beaches
     */
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beaches = await _context.Beaches.ToListAsync(cancellationToken);
        var filteredBeaches = beaches
                .Where(x => x.Location.Country != request.Country && x.Location.City != request.City)
                .OrderBy(x=>x.AverageScore);
        
        return new Response(filteredBeaches.Select(x => x.AsDto()).ToList());
    }
}