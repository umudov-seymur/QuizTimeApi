using Microsoft.EntityFrameworkCore;
using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizTime.Data.Implementations
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        private AppDbContext _context;
        public ResultRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Result> GetLastResultAsync(Expression<Func<Result, bool>> filter = null)
        {
            return await _context.Results
                .Where(filter)
                .OrderByDescending(n => n.Id)
                .FirstOrDefaultAsync();
        }
    }
}
