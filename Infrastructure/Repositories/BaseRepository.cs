using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly DatabaseContext _context;

    protected BaseRepository(DatabaseContext context)
    {
        _context = context;
    }


    // Create
    public virtual async Task<TEntity> Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
        }
    }

    // Read all
    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();

        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
       }
    }

    // Read One
    public virtual async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
        }
    }


    // Update
    // We use abstract here because we want to force the child classes to implement this method
    //public abstract TEntity Update(TEntity entity);
    public virtual async Task<TEntity> Update(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().FindAsync(entity);
            if(entity != null)
            {
                _context.Set<TEntity>().Update(entity);
                 await _context.SaveChangesAsync();
                return entity;
            }
            return null!;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
        }
    }

    // Delete
    public virtual async Task<bool> Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return false;
        }
    }

}
