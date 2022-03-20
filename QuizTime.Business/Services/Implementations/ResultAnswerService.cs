using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.ResultAnswers;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Extensions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class ResultAnswerService : IResultAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResultAnswerService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SaveAnswersByQuizPasswordAsync(string password, ResultAnswersPostForStudentDto resultAnswersPostDto)
        {
            var quiz = await _unitOfWork.QuizRepository.GetAsync(q => q.Password.Content == password, "Password");
            if (quiz is null) throw new NotFoundException("Quiz could not found");

            var lastResult = await GetActiveResultAsync(quiz);
            if (lastResult is null) throw new NotFoundException("Result not found");

            foreach (var studentAnswer in resultAnswersPostDto.Answers)
            {
                var resultAnswer = new ResultAnswer
                {
                    ResultId = lastResult.Id,
                    QuestionId = Guid.Parse(resultAnswersPostDto.QuestionId),
                    AnswerId = Guid.Parse(studentAnswer.AnswerId)
                };

                await _unitOfWork.ResultAnswerRepository.AddAsync(resultAnswer);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Result> GetActiveResultAsync(Quiz quiz)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();
            var quizResult = await _unitOfWork.ResultRepository.GetLastResultAsync(q => q.QuizId == quiz.Id && q.OwnerId == ownerId);

            if (!(quizResult is null))
            {
                var diffQuizStartedAt = (DateTime.Now - quizResult.StartedAt).TotalMinutes;
                if (quiz.Timer > diffQuizStartedAt) return quizResult;
            }

            return null;
        }
    }
}
