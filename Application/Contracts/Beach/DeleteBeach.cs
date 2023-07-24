using MediatR;

namespace Application.Contracts.Beach;

public class DeleteBeach
{
    public record struct Command(Guid BeachId) : IRequest;
}