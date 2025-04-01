using back_end.Interfaces;

namespace back_end.Exceptions;

public class UserAlreadyExistsException : Exception, IHasProblemDetails
{
    public int StatusCode { get; } = StatusCodes.Status409Conflict;
    public string Title { get; } = "Usuário já existe";
    public string? Detail { get; }
    
    public UserAlreadyExistsException(string username)
        : base($"O usuário {username} já existe!")
    {
        Detail = Message;
    }
}