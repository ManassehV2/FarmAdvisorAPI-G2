
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
        try{
        var result = _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return new ValueTask<T>(result.Entity);
        }
        catch (System.Exception e)
        {
            throw e;
        }

    }

    public ValueTask<T?> DeleteAsync(T entity)
    {
        try{
        var result = _context.Set<T>().Remove(entity);
        _context.SaveChanges();
        return new ValueTask<T?>(result.Entity);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }


    public  ValueTask<List<T>> GetAllAsync()
    {
        try{
        var result =  _context.Set<T>().ToListAsync();
        return new ValueTask<List<T>>(result);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }


    public ValueTask<T?> GetByIdAsync(Guid id)
    {
        try{
        var result =  _context.Set<T>().Find(id);
        return new ValueTask<T?>(result);
        }
        catch (System.Exception e)
        {
            throw e;
        }

    }

    

    public ValueTask<T?> UpdateAsync(T entity)
    {
        try{
        var result = _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return new ValueTask<T?>(result.Entity);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        
    }

}

}