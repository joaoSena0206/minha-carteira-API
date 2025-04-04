using back_end.Interfaces;

namespace back_end.Exceptions;

public class InvalidJwtToken : Exception, IHasProblemDetails
{
    public int StatusCode { get; } = StatusCodes.Status401Unauthorized;
    public string Title { get; } = "Token JWT inválido";
    public string? Detail { get; }

    public InvalidJwtToken()
        : base("Usuário não encontrado")
    {
        Detail = Message;
    }
}