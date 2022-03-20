using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Quiz.Setting;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Extensions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class QuizSettingService : IQuizSettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuizSettingService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task UpdateSettingsByQuizIdAsync(Guid id, QuizSettingPutDto quizPutDto)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();
            var quiz = await _unitOfWork.QuizRepository.GetAsync(quiz => quiz.Id == id && quiz.OwnerId == ownerId);

            if (quiz is null) throw new NotFoundException("Quiz could not found");

            var oldSetting = await _unitOfWork.QuizSettingRepository.GetAsync(s => s.QuizId == quiz.Id);
            var setting = _mapper.Map<QuizSettingPutDto, QuizSetting>(quizPutDto, oldSetting);

            await _unitOfWork.QuizSettingRepository.UpdateAsync(setting);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
