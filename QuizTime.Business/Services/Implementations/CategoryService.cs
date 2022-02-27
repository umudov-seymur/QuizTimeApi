using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Category;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Extensions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CategoryGetDto>> GetAllCategoryAsync()
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();
            return _mapper.Map<List<CategoryGetDto>>(
                await _unitOfWork.CategoryRepository.GetAllAsync(x => x.OwnerId == ownerId, "Quizzes"));
        }

        public async Task<CategoryGetDto> GetCategoryByIdAsync(Guid id)
        {
            return _mapper.Map<CategoryGetDto>(await GetCategoryOfOwner(id));
        }

        public async Task AddAsync(CategoryPostDto categoryPostDto)
        {
            var category = _mapper.Map<Category>(categoryPostDto);
            category.OwnerId = _httpContextAccessor.HttpContext.User.GetUserId();

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CategoryGetDto> UpdateAsync(Guid id, CategoryPutDto categoryPutDto)
        {
            var oldCategory = await GetCategoryOfOwner(id);
            var category = _mapper.Map<CategoryPutDto, Category>(categoryPutDto, oldCategory);

            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryGetDto>(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await GetCategoryOfOwner(id);
            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Category> GetCategoryOfOwner(Guid id)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();

            var category = await _unitOfWork.CategoryRepository
                    .GetAsync(cat => cat.Id == id && cat.OwnerId == ownerId, "Quizzes");

            if (category is null) throw new NotFoundException("Category could not found");

            return category;
        }
    }
}
