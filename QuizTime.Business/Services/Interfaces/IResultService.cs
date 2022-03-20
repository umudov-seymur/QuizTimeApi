using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Result;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IResultService
    {
        Task<ResultGetOfJoinedStudent> AddResultByQuizPasswordAsync(string password);
    }
}
