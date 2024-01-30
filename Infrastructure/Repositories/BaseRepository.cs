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
    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
        }
    }

    // Read All
    
    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
           
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
        }
    }


    // Read one by predicate
    public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            return entity!;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null!;
       }
    }

    // Read One by Id
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
    public virtual TEntity Update(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entityToUpdate;
            }
            else
            {
                return null!;
            }
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
