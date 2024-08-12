using FinancialManager.Api.Data;
using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description
        };

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return new Response<Category?>(category, 201);
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
        if (category is null) return new Response<Category?>(null, 404, "Category not found");

        category.Title = request.Title;
        category.Description = request.Description;

        context.Categories.Update(category);
        await context.SaveChangesAsync();

        return new Response<Category?>(category);
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        // .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
        if (category is null) return new Response<Category?>(null, 404, "Category not found");

        context.Categories.Remove(category);
        await context.SaveChangesAsync();

        return new Response<Category?>(category, message: "Category deleted");
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        var category = await context.Categories.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return category is null
            ? new Response<Category?>(null, 404, "Category not found")
            : new Response<Category?>(category);
    }

    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        var query = context.Categories
            .AsNoTracking()
            // .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.Title);
        var categories = await query
            .Skip((request.PageSize - 1) * request.PageNumber)
            .Take(request.PageSize)
            .ToListAsync();
        var count = await query.CountAsync();

        return new PagedResponse<List<Category>>(categories, count, request.PageSize);
    }
}