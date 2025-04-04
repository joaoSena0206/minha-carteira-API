namespace back_end.DTOs;

public class FilterTransactionDto
{
    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public bool? IsCredit { get; set; } = null;
    public int? CategoryId { get; set; } = null;
}