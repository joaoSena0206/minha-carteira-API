using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using back_end.Models;

namespace back_end.DTOs;

public class ShowFinancialGoalDto
{
    public int Id { get; set; }
    
    public Category Category { get; set; } = new Category();
    
    public int Month { get; set; }
    
    public int Year { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal ValueLimit { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal SpentValue { get; set; }
    
    public string Status { get; set; }
}