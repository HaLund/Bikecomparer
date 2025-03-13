using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        //Task<T> AddAsync(T entity);
        //Task<T> UpdateAsync(T entity);
        //Task<T> DeleteAsync(int id);
    }
}
