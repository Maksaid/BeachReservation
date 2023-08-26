using Application.Abstractions.DataAccess;
using Application.Abstractions.JwtAuth;
using Application.Exceptions;
using Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Users.LoginUser;

namespace Application.Handlers.Users;

internal  class LoginUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    private readonly IJwtProvider _jwtProvider;

    public LoginUserHandler(IDatabaseContext context, IJwtProvider jwtProvider)
    {
        _context = context;
        _jwtProvider = jwtProvider;
    }
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(request.Email), cancellationToken);
        if (user is null)
            throw new WrongCredentialsException("wrong email or password");
        if (user.Password != request.Password.Hash())
            throw new WrongCredentialsException("wrong email or password");

        string token = _jwtProvider.Generate(user);
        
        
        return new Response(token, user.AsDto());
    }
    
}