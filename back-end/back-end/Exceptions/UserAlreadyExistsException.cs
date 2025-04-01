namespace back_end.Exceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException()
        : base("O usuário já existe!")
    {
    }
}