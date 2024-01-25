﻿using Infrastructure.Contexts;
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

    // Read all
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

    // Read One
    public virtual TEntity GetById(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);

            if(entity != null)
            {
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

    // Update
    // We use abstract here because we want to force the child classes to implement this method
    //public abstract TEntity Update(TEntity entity);
    public virtual TEntity Update(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Find(entity);
            if(entity != null)
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
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
    public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
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