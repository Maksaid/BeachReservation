
using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Entities;
using MediatR;
using static Application.Contracts.Beach.AddImages;

namespace Application.Handlers.Beaches;

public class AddImageHandler : IRequestHandler<Command,Response>
{
    
    private readonly IDatabaseContext _context;

    public AddImageHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var beach = await _context.Beaches.GetEntityAsync(request.BeachId, cancellationToken);
        Image newImage = new Image(Guid.NewGuid(), request.Data, request.BeachId, request.PictureType);
        await _context.Images.AddEntityAsync(newImage, cancellationToken);
        beach.BeachImages.Add(newImage);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(beach.AsDto());
    }
}