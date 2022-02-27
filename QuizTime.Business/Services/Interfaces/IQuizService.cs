using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizGetForOwnerDto>> GetAllQuizzesync(QuizQuery query);
        Task<QuizGetForOwnerDto> GetQuizById(Guid id);
        Task AddAsync(QuizPostForOwnerDto quizPostDto);
        Task<QuizGetForOwnerDto> UpdateAsync(Guid id, QuizPutForOwnerDto quizPutDto);
        Task DeleteAsync(Guid id);
    }
}
