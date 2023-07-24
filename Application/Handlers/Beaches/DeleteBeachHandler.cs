using Application.Abstractions.DataAccess;
using Application.Extensions;
using MediatR;
using static Application.Contracts.Beach.DeleteBeach;

namespace Application.Handlers.Beaches;

public class DeleteBeachHandler : IRequestHandler<Command>
    {
    private readonly IDatabaseContext _context;

    public DeleteBeachHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId, cancellationToken);
        _context.Beaches.Remove(beach);
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}
