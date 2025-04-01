using System.Security.Claims;
using back_end.DTOs;
using back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

[ApiController]
[Route("api/transaction")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddTransaction(AddTransactionDto transactionDto)
    {
        string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        int transactionId = await _transactionService.AddTransaction(transactionDto, username);
        
        return StatusCode(201, new { message = "Transação adicionada com sucesso!", transactionId = transactionId });
    }
}