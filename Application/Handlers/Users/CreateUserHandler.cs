using Application.Abstractions.DataAccess;
using Application.Exceptions;
using Application.Mapping;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Users.CreateUser;

namespace Application.Handlers.Users;

public class CreateUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateUserHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Name, request.Email, request.Password.Hash(), request.Phone);
        if (await _context.Users.ContainsAsync(user,cancellationToken))
        {
            throw new UserAlreadyExistsException("this user already exists");
        }
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return new Response(user.AsDto());
    }
}