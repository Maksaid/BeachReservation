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
    public async Task<ActionResult<BeachDto>> AddImagesAsync([FromForm] IFormFile[] files, [FromForm] Guid beachId)
    {
        var command = new AddImages.Command(ConvertFormFileToByteArray(files),beachId);
        var updatedBeach = await _mediator.Send(command, CancellationToken);
        return Ok(updatedBeach);
    }
    
    private List<byte[]> ConvertFormFileToByteArray(IFormFile[] files)
    {
        List<byte[]> byteArrays = new List<byte[]>();
        
        foreach (var file in files)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                byteArrays.Add(memoryStream.ToArray());
            }
        }

        return byteArrays;
    }
}