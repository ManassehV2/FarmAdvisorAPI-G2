
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FarmAdvisor.DataAccess.MSSQL.Implementations
{

public class GenericRepositoryImpl<T> : IGenericRepository<T> where T : class
{
    private readonly FarmAdvisorDbContext _context;

    public GenericRepositoryImpl(FarmAdvisorDbContext context)
    {
        _context = context;
    }


    public ValueTask<T> AddAsync(T entity)
    {
        var result = _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return new ValueTask<T>(result.Entity);

    }

    public ValueTask<T?> DeleteAsync(T entity)
    {
        var result = _context.Set<T>().Remove(entity);
        _context.SaveChanges();
        return new ValueTask<T?>(result.Entity);
    }


    public  ValueTask<List<T>> GetAllAsync()
    {
        var result =  _context.Set<T>().ToListAsync();
        return new ValueTask<List<T>>(result);
    }


    public ValueTask<T?> GetByIdAsync(Guid id)
    {
        var result =  _context.Set<T>().Find(id);
        return new ValueTask<T?>(result);

    }


    public ValueTask<T?> UpdateAsync(T entity)
    {
        var result = _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return new ValueTask<T?>(result.Entity);

        
    }

}

}