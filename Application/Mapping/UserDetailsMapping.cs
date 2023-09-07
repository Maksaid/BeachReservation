using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class UserDetailsMapping
{
    public static UserDetailsDto AsDetailsDto(this User user, List<Beach> beaches, List<Review> reviews,
        List<Reservation> reservations)
    {
        return new UserDetailsDto(user.AsDto(), beaches.Select(x => x.AsShortDto()).ToList(),
            reviews.Select(x => x.AsDto()).ToList(), reservations.Select(x => x.AsDto()).ToList());
    }
}