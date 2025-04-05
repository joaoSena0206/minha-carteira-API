using back_end.Interfaces;

namespace back_end.Exceptions;

public class NotFoundTransaction : Exception, IHasProblemDetails
{
    public int StatusCode { get; } = StatusCodes.Status404NotFound;
    public string Title { get; } = "Transação não encontrada";
    public string? Detail { get; }

    public NotFoundTransaction(int transactionId)
        : base($"Transação {transactionId} não encontrada")
    {
        Detail = Message;
    }
}