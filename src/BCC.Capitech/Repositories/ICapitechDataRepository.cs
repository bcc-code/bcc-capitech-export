using BCC.Capitech.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BCC.Capitech.Repositories
{
    public interface ICapitechDataRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(int clientId);

        Task<List<T>> UpdateAsync(IList<T> items);

        Task<List<T>> AddAsync(IList<T> items);

        Task<List<T>> RemoveAsync(IList<T> items);

        Task<List<T>> QueryAsync(int clientId, Expression<Func<T, bool>> query);
    }
}