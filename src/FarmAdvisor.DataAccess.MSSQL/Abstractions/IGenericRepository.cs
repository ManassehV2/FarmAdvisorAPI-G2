
namespace FarmAdvisor.DataAccess.MSSQL.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        ValueTask<T> GetByIdAsync(Guid id);
        ValueTask<IEnumerable<T>> GetAllAsync();
        ValueTask<T> AddAsync(T entity);
        
        ValueTask<T> UpdateAsync(T entity);
        ValueTask<T> DeleteAsync(T entity);
    }
}