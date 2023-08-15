using Application.Contracts.Beach;
using Application.Contracts.Users;
using Application.Dto;
using Domain.Entities;
using MediatR;
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

    
    [HttpPost("add-images")]
    public async Task<ActionResult<BeachDto>> AddImagesAsync([FromBody] ImageModel imageToAdd,
        CancellationToken cancellationToken)
    {
        var command = new AddImages.Command(imageToAdd.Data,imageToAdd.BeachId,imageToAdd.PictureType);
        var updatedBeach = await _mediator.Send(command, cancellationToken);
        return Ok(updatedBeach);
    }
}