using Quiztime.Core.Interfaces;
using System.Threading.Tasks;

namespace Quiztime.Core
{
    public interface IUnitOfWork
    {
        IQuizRepository QuizRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IPasswordRepository PasswordRepository { get; }
        IQuizSettingRepository QuizSettingRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        IResultRepository ResultRepository { get; }
        IResultAnswerRepository ResultAnswerRepository { get; }
        Task SaveChangesAsync();
    }
}
