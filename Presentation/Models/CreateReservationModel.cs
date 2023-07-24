namespace Presentation.Models;

public record CreateReservationModel(Guid UmbrellaId, DateTime DateFrom, DateTime DateTo, Guid BeachId)
{
    
}