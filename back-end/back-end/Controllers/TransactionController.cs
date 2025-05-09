using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using back_end.DTOs;
using back_end.Models;
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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetTransactions([FromQuery] FilterTransactionDto filterTransactionDto)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var transactions = await _transactionService.GetTransactions(username, filterTransactionDto);
        
        return Ok(transactions);
    }

    [HttpGet("balance")]
    [Authorize]
    public async Task<IActionResult> GetBalance()
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        decimal balance = await _transactionService.GetBalance(username);
        
        return Ok(balance);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddTransaction(AddTransactionDto transactionDto)
    {
        string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        int transactionId = await _transactionService.AddTransaction(transactionDto, username);
        
        return StatusCode(201, new { message = "Transação adicionada com sucesso!", transactionId = transactionId });
    }

    [HttpPatch("{id:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateTransaction(int id, UpdateTransactionDto transactionDto)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        await _transactionService.UpdateTransaction(transactionDto, username, id);
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        await _transactionService.DeleteTransaction(id, username);
        
        return NoContent();
    }
}