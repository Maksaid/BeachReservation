using System.Security.Claims;
using Application.Contracts.Reservation;
using Application.Dto;
using Application.Handlers.Reservations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [Authorize]
    [HttpPost("create-reservation")]
    public async Task<ActionResult<ReservationDto>> CreateAsync([FromBody] CreateReservationModel reservationModel)
    {
        var currUserId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        if (currUserId is null)
        {
            throw new UnauthorizedAccessException();
        }

        var command = new CreateReservation.Command(reservationModel.UmbrellaId,Guid.Parse(currUserId.Value), reservationModel.DateFrom,reservationModel.DateTo,reservationModel.BeachId);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.ReservationDto);
    }

    [Authorize]
    [HttpDelete("delete-reservation")]
    public async Task<ActionResult> DeleteAsync(Guid reservationId)
    {
        var currUserId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        if (currUserId is null)
        {
            throw new UnauthorizedAccessException();
        }

        var command = new DeleteReservation.Command(reservationId);
        await _mediator.Send(command, CancellationToken);
        return Ok();
    } 
}