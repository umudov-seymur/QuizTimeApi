using QuizTime.Business.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionGetOfTeacherDto>> GetAllQuestionsByQuizIdAsync(Guid quizId);
        Task<QuestionGetOfTeacherDto> GetQuestionByQuizIdAsync(Guid quizId, Guid questionId);
        Task<QuestionGetOfTeacherDto> GetQuestionByIdAsync(Guid questionId);
        Task<QuestionGetOfTeacherDto> AddAsync(QuestionPostDto questionPostDto);
        Task UpdateOrderByQuizIdAsync(Guid quizId, List<QuestionOrderPatchDto> questionsOrderDto);
        Task DeleteAsync(Guid id);
    }
}
