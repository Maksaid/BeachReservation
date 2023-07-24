using Application.Dto;
using MediatR;

namespace Application.Contracts.Beach;

public class GetBeachById
{
    public record struct Command(Guid BeachId) : IRequest<Response>;

    public record struct Response(BeachDto BeachDto);

}