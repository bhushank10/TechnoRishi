using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechnoRishi.LMS.Repository.Interfaces;

namespace TechnoRishi.LMS.Repository;

public class Repository<T> : IRepository<T> where T : class 
{
    private DbSet<T> _dbSet;
    private LibraryContext _context;

    public Repository(LibraryContext context)
    {
       _dbSet =  context.Set<T>();
        _context = context;
    }

    public async Task<T> Add(T entity, CancellationToken token) 
    {
         _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync(token);
        return entity;
    }

    public async Task<bool> Delete(int id, CancellationToken token) 
    {
        //var dbSet = _dbSet.Set<T>();

        var entity = await Get(id,token);
        if (entity == null)
        {
            return false;
        }

        _context.Remove(entity);
        await _context.SaveChangesAsync(token);
        return true;
    }

    public async Task<T> Get(int id, CancellationToken token)
    {
        return await _dbSet.FindAsync(new object[] { id }, token);
    }

    public async Task<List<T>> GetAll< T2>(T2 filter, CancellationToken token)  where T2 : class
    {
        // Assuming filter is a query modifier like Func<IQueryable<T>, IQueryable<T>>
        if (filter is Func<IQueryable<T>, IQueryable<T>> applyFilter)
        {
            return await applyFilter(_dbSet).ToListAsync(token);
        }

        return await _dbSet.ToListAsync(token);
    }

    public async Task<bool> Update(object id, T entity, CancellationToken token) 
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(token);
        //return entity;

        return true;
    }



}
