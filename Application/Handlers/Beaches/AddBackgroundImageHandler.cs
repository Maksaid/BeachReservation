
using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Entities;
using Domain.Models;
using MediatR;
using static Application.Contracts.Beach.AddImages;

namespace Application.Handlers.Beaches;

public class AddBackgroundImageHandler : IRequestHandler<Command,Response>
{
    
    private readonly IDatabaseContext _context;

    public AddBackgroundImageHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId, cancellationToken);
        foreach (var byteArray in request.Data)
        {
            await _context.Images.AddEntityAsync(new Image(Guid.NewGuid(), byteArray, request.BeachId),cancellationToken);
        }
        
        // beach.BeachImages.Add(newImage);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(beach.AsDto());
    }
}