using Quiztime.Core.Interfaces;
using System.Threading.Tasks;

namespace Quiztime.Core
{
    public interface IUnitOfWork
    {
        IQuizRepository QuizRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IPasswordRepository PasswordRepository { get; }
        Task SaveChangesAsync();
    }
}
