using QuizTime.Business.DTOs.Result;
using QuizTime.Business.DTOs.ResultAnswers;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IResultAnswerService
    {
        Task SaveAnswersByQuizPasswordAsync(string password, ResultAnswersPostForStudentDto resultAnswersPostDto);
    }
}
