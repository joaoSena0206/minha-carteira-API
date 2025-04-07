using back_end.Data;
using back_end.DTOs;
using back_end.Exceptions;
using back_end.Models;

namespace back_end.Services;

public class TransactionService
{
    private readonly TransactionRepository _transactionRepository;
    private readonly UserRepository _userRepository;
    private readonly CategoryRepository _categoryRepository;

    public TransactionService(
        TransactionRepository transactionRepository,
        UserRepository userRepository,
        CategoryRepository categoryRepository)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<int> AddTransaction(AddTransactionDto transactionDto, string username)
    {
        Transaction transaction = new Transaction
        {
            Value = transactionDto.Value,
            Description = transactionDto.Description,
            IsCredit = transactionDto.IsCredit,
            Date  = transactionDto.Date,
            User = await _userRepository.GetUser(username),
            Category = transactionDto.CategoryId != 0 ? await _categoryRepository.GetCategory(transactionDto.CategoryId, username) ??
                       throw new NotFoundCategoryException(transactionDto.CategoryId) : null
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
       transaction.Category = transactionDto.CategoryId != 0 && transactionDto.CategoryId != null
           ? await _categoryRepository.GetCategory((int)transactionDto.CategoryId, username) ??
             throw new NotFoundCategoryException((int)transactionDto.CategoryId)
           : null;

       await _transactionRepository.SaveChanges();
    }

    public async Task DeleteTransaction(int transactionId, string username)
    {
        Transaction transaction = await _transactionRepository.GetTransaction(transactionId, username);

        if (transaction == null)
        {
            throw new NotFoundTransaction(transactionId);
        }
        
        await _transactionRepository.DeleteTransaction(transaction);
    }
}