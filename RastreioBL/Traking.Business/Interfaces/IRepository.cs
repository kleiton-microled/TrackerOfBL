using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traking.Business.Models;

namespace Traking.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<T> FindBlByToken(string token);
        Task<int> SaveChanges();
    }
}
