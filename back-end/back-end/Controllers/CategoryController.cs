using System.Security.Claims;
using back_end.DTOs;
using back_end.Models;
using back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(AddCategoryDto categoryDto)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        int categoryId = await _categoryService.AddCategory(categoryDto, username);

        return StatusCode(201, new { categoryId = categoryId });
    }
}