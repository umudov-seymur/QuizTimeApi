using System;
using AutoMapper;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.Services.Interfaces;
using System.Threading.Tasks;
using QuizTime.Business.DTOs.Question.Answers;
using System.Collections.Generic;
using System.Linq;

namespace QuizTime.Business.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAnswerByQuestionIdAsync(Guid questionId, List<AnswerPostDto> answersPostDto)
        {
            answersPostDto.Select(answer =>
            {
                answer.QuestionId = questionId.ToString();
                return answer;
            }).ToList();

            var answers = _mapper.Map<List<Answer>>(answersPostDto);
            await _unitOfWork.AnswerRepository.AddRangeAsync(answers);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
