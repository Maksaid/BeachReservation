using Application.Dto;
using MediatR;

namespace Application.Contracts.Users;

public static class GetUserDetails
{
    public record struct Command(Guid Id) : IRequest<Response>;

    public record struct Response(UserDetailsDto UserDto);
}