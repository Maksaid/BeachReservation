using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class UserMapping
{
    public static UserDto AsDto(this User user)
    {
        return new UserDto(user.Id, user.Email, user.Name, user.Email, user.Phone);
    }
}