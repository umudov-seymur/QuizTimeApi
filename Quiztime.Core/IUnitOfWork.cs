using Quiztime.Core.Interfaces;
using System.Threading.Tasks;

namespace Quiztime.Core
{
    public interface IUnitOfWork
    {
        IQuizRepository QuizRepository { get; }
        IPasswordRepository PasswordRepository { get; }
        Task SaveChangesAsync();
    }
}
