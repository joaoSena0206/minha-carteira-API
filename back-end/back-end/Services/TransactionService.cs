using back_end.Data;
using back_end.DTOs;
using back_end.Exceptions;
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

    public async Task<decimal> GetBalance(string username)
    {
        decimal balance = await _transactionRepository.GetBalance(username);
        
        return balance;
    }

    public async Task<IList<Transaction>> GetTransactions(string username, FilterTransactionDto filterTransactionDto)
    {
        return await  _transactionRepository.GetTransactions(
            username,
            filterTransactionDto.StartDate,
            filterTransactionDto.EndDate,
            filterTransactionDto.IsCredit,
            filterTransactionDto.CategoryId);
    }

    public async Task UpdateTransaction(UpdateTransactionDto transactionDto, string username, int transactionId)
    {
       Transaction transaction = await _transactionRepository.GetTransaction(transactionId, username);

       if (transaction == null)
       {
           throw new NotFoundTransaction(transactionId);
       }
       
       transaction.Value = transactionDto.Value ?? transaction.Value;
       transaction.Description = transactionDto.Description ?? transaction.Description;
       transaction.IsCredit = transactionDto.IsCredit ?? transaction.IsCredit;
       transaction.Date = transactionDto.Date ?? transaction.Date;
       transaction.CategoryId = transactionDto.CategoryId ?? transaction.CategoryId;

       await _transactionRepository.SaveChanges();
    }
}