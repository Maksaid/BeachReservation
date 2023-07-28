using Application.Dto;
using MediatR;

namespace Application.Contracts.Beach;

public class GetAllBeaches
{
    public record struct Command : IRequest<Response>;
    public record struct Response(List<BeachShortDto> BeachDtos);

}