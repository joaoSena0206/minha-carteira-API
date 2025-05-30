using System.Security.Claims;
using back_end.DTOs;
using back_end.Models;
using back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

[ApiController]
[Route("api/financial-goal")]
public class FinancialGoalController : ControllerBase
{
    private readonly FinancialGoalService _financialGoalService;

    public FinancialGoalController(FinancialGoalService financialGoalService)
    {
        _financialGoalService = financialGoalService;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(AddFinancialGoalDto financialGoalDto)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        int id = await _financialGoalService.Create(financialGoalDto, username);
        
        return StatusCode(201, new { financialGoalId = id });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int? year, [FromQuery] int? month)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        List<ShowFinancialGoalDto> financialGoals = await _financialGoalService.GetAll(month, year, username);
        
        return Ok(financialGoals);
    }

    [HttpPatch("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, UpdateFinancialGoalDto financialGoalDto)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        await _financialGoalService.Update(financialGoalDto, username, id);
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        await _financialGoalService.Delete(id, username);
        
        return NoContent();
    }
}