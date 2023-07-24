using Application.Abstractions.DataAccess;
using Application.Exceptions;
using Application.Extensions;
using MediatR;

using static Application.Contracts.Users.DeleteUser;

namespace Application.Handlers.Users;

public class DeleteUserHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public DeleteUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.GetEntityAsync(request.UserId, cancellationToken);
        if (user is null) throw new NotFoundException("user not found");
         _context.Users.Remove(user);
    }
}