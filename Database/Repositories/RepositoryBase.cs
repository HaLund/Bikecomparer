using Database.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly BikeComparerContext _context;
        protected readonly DbSet<T> _dbSet;
        public RepositoryBase(BikeComparerContext context) 
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        //public Task<T> AddAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> UpdateAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
