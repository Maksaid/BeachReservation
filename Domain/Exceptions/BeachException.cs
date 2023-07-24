using Domain.Entities;

namespace Domain.Exceptions;

public class BeachException : DomainException
{
    private BeachException(string? message) : base(message){}

    public static BeachException NotEnoughColumns(Guid beachId, int columnsCount) =>
        new BeachException($"there must be at least 4 columns, provided: {columnsCount} on beach: {beachId}");
    public static BeachException NotEnoughRows(Guid beachId, int rowsCount) =>
        new BeachException($"there must be at least 2 rows, provided: {rowsCount} on beach: {beachId}");
    
}