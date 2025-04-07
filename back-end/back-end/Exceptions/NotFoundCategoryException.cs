using back_end.Interfaces;

namespace back_end.Exceptions;

public class NotFoundCategoryException : Exception, IHasProblemDetails
{
    public int StatusCode { get; set; } = StatusCodes.Status404NotFound;
    public string Title { get; set; } = "Categoria não encontrada";
    public string? Detail  { get; set; }

    public NotFoundCategoryException(int id)
        : base($"Categoria {id} não encontrada")
    {
        Detail = Message;
    }
}