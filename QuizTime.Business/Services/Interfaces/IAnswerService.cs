using QuizTime.Business.DTOs.Question.Answers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IAnswerService
    {
        Task AddAnswerByQuestionIdAsync(Guid quesitonId, List<AnswerPostDto> answersPostDto);
    }
}
