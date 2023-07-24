using Domain.Entities;

namespace Application.Abstractions.JwtAuth;

public interface IJwtProvider
{
    string Generate(User user); 
}