using System.Security.Claims;
using Application.Contracts.Beach;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeachController : ControllerBase
{
    private readonly IMediator _mediator;

    public BeachController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [Authorize]
    [HttpPost("create-beach")]
    public async Task<ActionResult<BeachDto>> CreateAsync([FromBody] CreateBeachModel beachModel)
    {
        var currUserId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        if (currUserId is null)
        {
            throw new UnauthorizedAccessException();
        }

        var command = new CreateBeach.Command(Guid.Parse(currUserId.Value), beachModel.Name, beachModel.Description,
            beachModel.RowsCount,
            beachModel.ColsCount,
            beachModel.Indexes,
            beachModel.Country,
            beachModel.City,
            beachModel.Longitude,
            beachModel.Latitude);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.BeachDto);
    }

    [HttpGet("get-beach")]
    public async Task<ActionResult<BeachDto>> GetBeachById(Guid beachId)
    {
        Console.WriteLine(beachId);
        var command = new GetBeachById.Command(beachId);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.BeachDto);
    }

    [HttpGet("get-all-beaches")]
    public async Task<ActionResult<List<BeachShortDto>>> GetAllBeaches()
    {
        var command = new GetAllBeaches.Command();
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.BeachDtos);
    }

    [HttpGet("get-beaches-by-location")]
    public async Task<ActionResult<List<BeachDto>>> GetBeachesByLocation([FromBody] LocationModel location)
    {
        var command =
            new GetBeachesByLocation.Command(location.Country, location.City, location.Longitude, location.Latitude);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.BeachDtos);
    }

    [HttpDelete("delete-beach")]
    public async Task<ActionResult> DeleteBeach(Guid beachId)
    {
        var command = new DeleteBeach.Command(beachId);
        await _mediator.Send(command, CancellationToken);
        return Ok(new { message = $"beach with id: {beachId} was deleted" });
    }
}