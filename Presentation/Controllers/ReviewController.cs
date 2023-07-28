using System.Security.Claims;
using Application.Contracts.Beach;
using Application.Contracts.Review;
using Application.Dto;
using Application.Handlers.Reviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [Authorize]
    [HttpPost("add-review")]
    public async Task<ActionResult<ReviewDto>> CreateAsync([FromBody] AddReviewModel reviewModel)
    {
        var currUserId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        if (currUserId is null)
        {
            throw new UnauthorizedAccessException();
        }
        var command = new AddReview.Command(reviewModel.BeachId,Guid.Parse(currUserId.Value),reviewModel.Score ,reviewModel.Text);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.ReviewDto); 
    }
    
    [Authorize]
    [HttpPost("update-review")]
    public async Task<ActionResult<ReviewDto>> UpdateAsync([FromBody] UpdateReviewModel reviewModel)
    {
        var currUserId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Sid);
        if (currUserId is null)
        {
            throw new UnauthorizedAccessException();
        }
        var command = new UpdateReview.Command(reviewModel.ReviewId,reviewModel.NewReviewScore,reviewModel.NewText);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.ReviewDto); 
    }
    
    [HttpDelete("delete-review")]
    public async Task<ActionResult> DeleteReview(Guid reviewId)
    {
        var command = new DeleteReview.Command(reviewId);
        await _mediator.Send(command, CancellationToken);
        return Ok();
    }
    
    [HttpGet("get-beach-reviews")]
    public async Task<ActionResult<List<ReviewDto>>> GetBeachReviews(Guid beachId)
    {
        var command = new GetBeachReviews.Command(beachId);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.ReviewDtos);
    }
}