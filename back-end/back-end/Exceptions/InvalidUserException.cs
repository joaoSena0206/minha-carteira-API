using back_end.Interfaces;

namespace back_end.Exceptions;

public class InvalidUserException : Exception, IHasProblemDetails
{
    public int StatusCode { get; } = StatusCodes.Status401Unauthorized;
    public string Title { get; } = "Usuário invalido";
    public string? Detail { get; }

    public InvalidUserException()
        : base("Nome de usuário ou senha incorreta")
    {
        Detail = Message;
    }
}