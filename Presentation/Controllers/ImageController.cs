using Application.Contracts.Beach;
using Application.Contracts.Users;
using Application.Dto;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IMediator _mediator;
    public ImageController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public CancellationToken CancellationToken => HttpContext.RequestAborted;


    [Authorize]
    [HttpPost("add-background-image")]
    public async Task<ActionResult<BeachDto>> AddImagesAsync([FromForm] IFormFile file, [FromForm] Guid beachId)
    {
        var command = new AddImages.Command(ConvertFormFileToByteArray(file),beachId);
        var updatedBeach = await _mediator.Send(command, CancellationToken);
        return Ok(updatedBeach);
    }
    
    private byte[] ConvertFormFileToByteArray(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}