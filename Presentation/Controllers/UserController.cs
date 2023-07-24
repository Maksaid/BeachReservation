using Application.Contracts.Users;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUser.Command command, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(command, cancellationToken);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] CreateUserModel userModel,
            CancellationToken cancellationToken)
        {
            var command = new CreateUser.Command(userModel.Name, userModel.Email, userModel.Password, userModel.Phone);
            var newUser = await _mediator.Send(command, cancellationToken);
            return Ok(newUser);
        }
}