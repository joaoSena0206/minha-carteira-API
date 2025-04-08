using back_end.Interfaces;

namespace back_end.Exceptions;

public class NotFoundFinancialGoalException : Exception, IHasProblemDetails
{
    public int StatusCode { get; set; } = StatusCodes.Status404NotFound;
    public string Title { get; set; } = "Meta financeira não encontrada";
    public string? Detail  { get; set; }

    public NotFoundFinancialGoalException(int id)
        : base($"Meta financeira {id} não encontrada")
    {
        Detail = Message;
    }
}