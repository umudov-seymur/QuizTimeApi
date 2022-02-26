using Quiztime.Core;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using QuizTime.Data.Implementations;
using System.Threading.Tasks;

namespace QuizTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IQuizRepository _quizRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IQuizRepository QuizRepository => _quizRepository ??= new QuizRepository(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
