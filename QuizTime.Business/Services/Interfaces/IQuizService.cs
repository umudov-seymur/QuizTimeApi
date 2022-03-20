using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.Result;
using QuizTime.Business.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizGetForOwnerDto>> GetAllQuizzesAsync(QuizQuery query);
        Task<QuizGetForOwnerDto> GetQuizByIdAsync(Guid id);
        Task<QuizGetForStudent> GetQuizByPasswordAsync(string password);
        Task<QuizGetOfJoinedStudentDto> GetQuizForJoinedStudentAsync(string password);
        Task<QuizGetForOwnerDto> AddAsync(QuizPostForOwnerDto quizPostDto);
        Task<QuizGetForOwnerDto> UpdateAsync(Guid id, QuizPutForOwnerDto quizPutDto);
        Task DeleteAsync(Guid id);
    }
}
