using MediatR;

namespace Application.Contracts.Users;

public static class DeleteUser
{
    public record struct Command(Guid UserId) : IRequest;
}