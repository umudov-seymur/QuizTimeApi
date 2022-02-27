using QuizTime.Business.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDto>> GetAllCategoryAsync();
        Task<CategoryGetDto> GetCategoryByIdAsync(Guid id);
        Task AddAsync(CategoryPostDto categoryPostDto);
        Task<CategoryGetDto> UpdateAsync(Guid id, CategoryPutDto categoryPutDto);
        Task DeleteAsync(Guid id);
    }
}
