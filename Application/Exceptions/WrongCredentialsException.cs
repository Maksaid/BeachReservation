namespace Application.Exceptions;

public class WrongCredentialsException : NotFoundException
{
    public WrongCredentialsException(string? message) : base(message)
    {
    }
}