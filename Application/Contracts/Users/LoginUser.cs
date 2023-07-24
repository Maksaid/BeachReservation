
using MediatR;

namespace Application.Contracts.Users;

public static class LoginUser
{
    public record struct Command(string Email, string Password) : IRequest<Response>;

    public record struct Response(string Token);

}