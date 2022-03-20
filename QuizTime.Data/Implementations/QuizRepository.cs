using Microsoft.EntityFrameworkCore;
using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizTime.Data.Implementations
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private AppDbContext _context;
        public QuizRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync(Expression<Func<Quiz, bool>> filter = null)
        {
            var quizzes = _context.Quizzes
                .Include(n => n.Password)
                .Include(n => n.Category)
                .Include(n => n.Questions)
                .OrderByDescending(n => n.CreatedAt);

            return filter is null
                   ? await quizzes.ToListAsync()
                   : await quizzes.Where(filter).ToListAsync();
        }

        public async Task<Quiz> GetQuizByPasswordAsync(string password, params string[] includes)
        {
            return await GetAsync(x => x.Password.Content == password, includes);
        }
    }
}
