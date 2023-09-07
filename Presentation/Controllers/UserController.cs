using Application.Contracts.Users;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<LoginUser.Response>> LoginUser([FromBody] LoginModel loginModel, CancellationToken cancellationToken)
        {
            var request = new LoginUser.Command(loginModel.Email, loginModel.Password);
            var tokenAndUserData = await _mediator.Send(request, cancellationToken);
            return Ok(tokenAndUserData);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] CreateUserModel userModel,
            CancellationToken cancellationToken)
        {
            var command = new CreateUser.Command(userModel.Name, userModel.Email, userModel.Password, userModel.Phone);
            var newUser = await _mediator.Send(command, cancellationToken);
            return Ok(newUser);
        }

        [HttpGet("get-user-details")]

        public async Task<ActionResult<UserDetailsDto>> GetUserDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new GetUserDetails.Command(id);
            var userDetails = await _mediator.Send(command, cancellationToken);
            return Ok(userDetails);
        }
}