using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Result;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Extensions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResultService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResultGetOfJoinedStudent> AddResultByQuizPasswordAsync(string password)
        {
            var quiz = await _unitOfWork.QuizRepository.GetAsync(q => q.Password.Content == password, "Password");
            if (quiz is null) throw new NotFoundException("Quiz could not found");

            if (await CheckQuizIsStartedAsync(quiz)) throw new QuizIsAlreadyInProgressException("The quiz is already in progress");

            var result = new Result
            {
                OwnerId = _httpContextAccessor.HttpContext.User.GetUserId(),
                QuizId = quiz.Id,
                StartedAt = DateTime.Now
            };

            await _unitOfWork.ResultRepository.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ResultGetOfJoinedStudent>(result);
        }

        private async Task<bool> CheckQuizIsStartedAsync(Quiz quiz)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();
            var quizResult = await _unitOfWork.ResultRepository.GetLastResultAsync(q => q.QuizId == quiz.Id && q.OwnerId == ownerId);

            if (!(quizResult is null))
            {
                var diffQuizStartedAt = (DateTime.Now - quizResult.StartedAt).TotalMinutes;
                if (quiz.Timer > diffQuizStartedAt) return true;
            }

            return false;
        }
    }
}
