using QuizTime.Business.DTOs.Question.Answers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerGetOfTeacherDto> GetAnswerByIdAsync(Guid id);
        Task AddAnswerByQuestionIdAsync(Guid quesitonId, List<AnswerPostDto> answersPostDto);
        Task DeleteAsync(Guid id);
    }
}
