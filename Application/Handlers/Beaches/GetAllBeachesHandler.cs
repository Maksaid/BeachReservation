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
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beaches = await _context.Beaches.ToListAsync();
        return new Response(beaches.Select(x => x.AsDto()).ToList());
    }
}