using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using static Application.Contracts.Beach.GetBeachById;

namespace Application.Handlers.Beaches;

internal class GetBeachByIdHandler : IRequestHandler<Command,Response>
{
    private readonly IDatabaseContext _context;

    public GetBeachByIdHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId,cancellationToken);
        return new Response(beach.AsDto());
    }
}