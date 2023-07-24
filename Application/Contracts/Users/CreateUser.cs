using Application.Dto;
using MediatR;

namespace Application.Contracts.Users;

public static class CreateUser
{
    public record struct Command(string Name, string Email, string Password, string Phone) : IRequest<Response>;

    public record struct Response(UserDto UserDto);
}