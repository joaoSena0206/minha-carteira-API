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

    public FinancialGoalService(
        FinancialGoalRepository financialGoalRepository,
        CategoryRepository categoryRepository,
        UserRepository userRepository)
    {
        _financialGoalRepository = financialGoalRepository;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
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

    public async Task<List<FinancialGoal>> GetAll(int? month, int? year, string username)
    {
        return await _financialGoalRepository.GetAll(month, year, username);
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
}