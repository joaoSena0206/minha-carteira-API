using back_end.Data;
using back_end.DTOs;
using back_end.Models;

namespace back_end.Services;

public class TransactionService
{
    private readonly TransactionRepository _transactionRepository;

    public TransactionService(TransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<int> AddTransaction(AddTransactionDto transactionDto, string username)
    {
        Transaction transaction = new Transaction
        {
            Value = transactionDto.Value,
            Description = transactionDto.Description,
            IsCredit = transactionDto.IsCredit,
            Date  = transactionDto.Date,
            CategoryId = transactionDto.CategoryId == 0 ? null : transactionDto.CategoryId,
            Username = username
        };
        
        return await _transactionRepository.AddTransaction(transaction);
    }
}