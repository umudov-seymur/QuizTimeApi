using Microsoft.EntityFrameworkCore;
using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizTime.Data.Implementations
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private AppDbContext _context;
        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllQuestionsByQuizIdAsync(Guid quizId)
        {
            return await _context.Questions
                .Where(n => n.QuizId == quizId)
                .Include(n => n.Answers)
                .OrderBy(n => n.Order)
                .ThenByDescending(n => n.CreatedAt)
                .ToListAsync();
        }
    }
}
