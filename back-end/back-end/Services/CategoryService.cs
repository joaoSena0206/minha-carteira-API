using back_end.Data;
using back_end.DTOs;
using back_end.Models;

namespace back_end.Services;

public class CategoryService
{
    private readonly CategoryRepository _repository;

    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddCategory(AddCategoryDto categoryDto, string username)
    {
        Category category = new Category
        {
            Name = categoryDto.Name,
            Username = username
        };
        
        return await _repository.Add(category);
    }
}