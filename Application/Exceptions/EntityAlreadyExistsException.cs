namespace Application.Exceptions;

public class EntityAlreadyExistException<T> : NotFoundException
{
    private EntityAlreadyExistException(string? message) : base(message)
    {
    }

    public static EntityAlreadyExistException<T> Create(T t)
    {
        return new EntityAlreadyExistException<T>($"{typeof(T).Name} already exists");
    }
}