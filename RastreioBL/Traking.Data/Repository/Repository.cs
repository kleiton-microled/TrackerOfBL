using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traking.Business.Interfaces;
using Traking.Business.Models;
using Traking.Data.Context;

namespace Traking.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TrakingContext _context;
        protected readonly DbSet<T> _dbSet;
        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindBlByToken(string token)
        {
            return await _dbSet.FindAsync(token);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
