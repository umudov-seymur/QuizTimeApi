using Quiztime.Core.Interfaces;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IUnitOfWorkService
    {
        IQuizService QuizService { get; }
        ICategoryService CategoryService { get; }
        IQuestionService QuestionService { get; }
        IAnswerService AnswerService { get; }
    }
}
