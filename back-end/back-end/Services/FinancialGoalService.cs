using back_end.Data;
using back_end.DTOs;
using back_end.Exceptions;
using back_end.Models;

namespace back_end.Services;

public class FinancialGoalService
{
    private readonly FinancialGoalRepository _financialGoalRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly UserRepository _userRepository;
    private readonly TransactionRepository _transactionRepository;

    public FinancialGoalService(
        FinancialGoalRepository financialGoalRepository,
        CategoryRepository categoryRepository,
        UserRepository userRepository,
        TransactionRepository transactionRepository)
    {
        _financialGoalRepository = financialGoalRepository;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<int> Create(AddFinancialGoalDto financialGoalDto, string username)
    {
        FinancialGoal financialGoal = new FinancialGoal
        {
            ValueLimit = financialGoalDto.ValueLimit,
            Month = financialGoalDto.Month,
            Year = financialGoalDto.Year,
            User = await _userRepository.GetUser(username),
            Category = await _categoryRepository.GetCategory(financialGoalDto.CategoryId, username) ??
                       throw new NotFoundCategoryException(financialGoalDto.CategoryId)
        };
        
        return await _financialGoalRepository.Create(financialGoal);
    }

    public async Task<List<ShowFinancialGoalDto>> GetAll(int? month, int? year, string username)
    {
        List<FinancialGoalWithTransactionsDto> financialGoalsWithTransactions = await _financialGoalRepository.GetAll(month, year, username);
        List<ShowFinancialGoalDto> financialGoalsWithStatus = new List<ShowFinancialGoalDto>();

        foreach (var financialGoal in financialGoalsWithTransactions)
        {
            decimal valueSpent = financialGoal.Transactions.Sum(t => t.Value);
            string status = valueSpent > financialGoal.ValueLimit ? "estourado" : "ok";

            var financialGoalWithStatus = new ShowFinancialGoalDto
            {
                Id = financialGoal.Id,
                Month = financialGoal.Month,
                Year = financialGoal.Year,
                ValueLimit = financialGoal.ValueLimit,
                SpentValue = valueSpent,
                Status = status,
                Category = financialGoal.Category,
            };
            
            financialGoalsWithStatus.Add(financialGoalWithStatus);
        }

        return financialGoalsWithStatus;
    }

    public async Task Update(UpdateFinancialGoalDto financialGoalDto, string username, int id)
    {
        FinancialGoal financialGoal = await _financialGoalRepository.GetById(id, username);

        if (financialGoal == null)
        {
            throw new NotFoundFinancialGoalException(id);
        }
        
        financialGoal.ValueLimit = financialGoalDto.ValueLimit ?? financialGoal.ValueLimit;
        financialGoal.Month = financialGoalDto.Month ?? financialGoal.Month;
        financialGoal.Year = financialGoalDto.Year ?? financialGoal.Year;
        financialGoal.Category = financialGoalDto.CategoryId != null ?
            await _categoryRepository.GetCategory((int)financialGoalDto.CategoryId, username)
            ?? throw new NotFoundCategoryException((int)financialGoalDto.CategoryId)
            : financialGoal.Category;

        await _financialGoalRepository.SaveChanges();
    }

    public async Task Delete(int id, string username)
    {
        FinancialGoal financialGoal = await _financialGoalRepository.GetById(id, username);

        if (financialGoal == null)
        {
            throw new NotFoundFinancialGoalException(id);
        }
        
        await _financialGoalRepository.Delete(financialGoal);
    }
}