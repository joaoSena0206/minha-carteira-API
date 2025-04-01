namespace back_end.Interfaces;

public interface IHasProblemDetails
{
    int StatusCode { get; }
    string Title { get; }
    string? Detail { get; }
}