using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using QuizTime.Business.DTOs.Category;
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

        public Task<CategoryGetDto> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
