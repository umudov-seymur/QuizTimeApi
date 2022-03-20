using QuizTime.Business.DTOs.Quiz.Setting;
using System;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IQuizSettingService
    {
        Task UpdateSettingsByQuizIdAsync(Guid id, QuizSettingPutDto quizPutDto);
    }
}
