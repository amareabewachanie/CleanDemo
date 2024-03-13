using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
