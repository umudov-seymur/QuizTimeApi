using QuizTime.Business.DTOs.Quiz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizGetDto>> GetAllQuizzesync();
    }
}
