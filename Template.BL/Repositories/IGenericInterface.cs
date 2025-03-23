using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.BL.Repositories
{
    public interface IGenericInterface<T>
    {
        Task<ResponseData<List<T>>> GetAllAsync();
        Task<ResponseData<T>> GetAsync(int id);
        Task<ResponseData> CreateAsync(T model);
        Task<ResponseData> UpdateAsync(T model, int id);
        Task<ResponseData> DeleteAsync(int id);
    }
}
