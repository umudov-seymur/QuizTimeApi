using Microsoft.EntityFrameworkCore;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizTime.Data.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        private AppDbContext _context { get; }

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            params string[] includes)
        {
            var query = GetQuery(includes);

            return filter is null
                ? await query.ToListAsync()
                : await query.Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            var query = GetQuery(includes);

            return filter is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter is null
                ? await _context.Set<TEntity>().CountAsync()
                : await _context.Set<TEntity>().Where(filter).CountAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().AnyAsync(filter);
        }

        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }
}
