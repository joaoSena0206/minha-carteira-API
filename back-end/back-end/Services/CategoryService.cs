using back_end.Data;
using back_end.DTOs;
using back_end.Exceptions;
using back_end.Models;

namespace back_end.Services;

public class CategoryService
{
    private readonly CategoryRepository _repository;
    private readonly UserRepository _userRepository;

    public CategoryService(CategoryRepository repository, UserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<int> AddCategory(AddCategoryDto categoryDto, string username)
    {
        Category category = new Category
        {
            Name = categoryDto.Name,
            User = await _userRepository.GetUser(username)
        };
        
        return await _repository.Add(category);
    }

    public async Task<List<Category>> GetCategories(string username)
    {
        List<Category> categories = await _repository.GetCategories(username);
        
        return categories;
    }

    public async Task UpdateCategory(int id, UpdateCategoryDto categoryDto, string username)
    {
        Category category = await _repository.GetCategory(id, username);

        if (category == null)
        {
            throw new NotFoundCategoryException(id);
        }
        
        category.Name = categoryDto.Name ?? category.Name;

        await _repository.SaveChanges();
    }
}