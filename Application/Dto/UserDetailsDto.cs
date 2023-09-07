namespace Application.Dto;

public record UserDetailsDto(UserDto User,List<BeachShortDto> Beaches, List<ReviewDto> Reviews, List<ReservationDto> Reservations){ }