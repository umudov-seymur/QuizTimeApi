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
        private IQuizSettingRepository _quizSettingRepository;
        private IPasswordRepository _passwordRepository;
        private ICategoryRepository _categoryRepository;
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;
        private IResultRepository _resultRepository;
        private IResultAnswerRepository _resultAnswerRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IQuizRepository QuizRepository => _quizRepository ??= new QuizRepository(_context);
        public IPasswordRepository PasswordRepository => _passwordRepository ??= new PasswordRepository(_context);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
        public IQuestionRepository QuestionRepository => _questionRepository ??= new QuestionRepository(_context);
        public IAnswerRepository AnswerRepository => _answerRepository ??= new AnswerRepository(_context);
        public IQuizSettingRepository QuizSettingRepository => _quizSettingRepository ??= new QuizSettingRepository(_context);
        public IResultRepository ResultRepository => _resultRepository ??= new ResultRepository(_context);
        public IResultAnswerRepository ResultAnswerRepository => _resultAnswerRepository ??= new ResultAnswerRepository(_context);

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
