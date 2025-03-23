using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.BL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task<List<T>> ReadAllAsync();
        Task<string> UpdateAsync(T entity, int id);
        Task<string> DeleteAsync(int id);
    }
}
