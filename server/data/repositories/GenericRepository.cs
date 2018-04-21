

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.data.repositories 
{  
  public abstract class GenericRepository<T> : IGenericRepository<T> where T : class  
  {  
    protected CRMContext _context;  
  
    public GenericRepository(CRMContext context)  
    {  
      _context = context;  
    }  
  
    public IQueryable<T> GetAll()  
    {  
      return _context.Set<T>();  
    }  
  
    public virtual async Task<ICollection<T>> GetAllAsync()  
    {  
  
      return await _context.Set<T>().ToListAsync();  
    }  
  
    public virtual T Get(int id)  
    {  
      return _context.Set<T>().Find(id);  
    }  
  
    public virtual async Task<T> GetAsync(int id)  
    {  
      return await _context.Set<T>().FindAsync(id);  
    }  
  
    public virtual T Add(T t)  
    {  
      using (var transaction = _context.Database.BeginTransaction()) {
        try {
          _context.Set<T>().Add(t);  
          _context.SaveChanges(); 
          transaction.Commit(); 
          return t;
        } catch {
          transaction.Rollback();
          return null;
        }
      }  
    }  
  
    public virtual async Task<T> AddAsyn(T t)  
    {  
      using (var transaction = _context.Database.BeginTransaction()) {
        try {
          _context.Set<T>().Add(t);  
          await _context.SaveChangesAsync();  
          transaction.Commit();
          return t;
        } catch {
          transaction.Rollback();
          return null;
        }
      }
    }  
  
    public virtual T Find(Expression<Func<T, bool>> match)  
    {  
      return _context.Set<T>().SingleOrDefault(match);  
    }  
  
    public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)  
    {  
      return await _context.Set<T>().SingleOrDefaultAsync(match);  
    }  
  
    public ICollection<T> FindAll(Expression<Func<T, bool>> match)  
    {  
      return _context.Set<T>().Where(match).ToList();  
    }  
  
    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)  
    {  
      return await _context.Set<T>().Where(match).ToListAsync();  
    }  
  
    public virtual void Delete(T entity)  
    {  
      using (var transaction = _context.Database.BeginTransaction()) {
        try {
          _context.Set<T>().Remove(entity);  
          _context.SaveChanges();
          transaction.Commit();
        } catch {
          transaction.Rollback();
        }
      }  
    }  
  
    public virtual async Task<int> DeleteAsyn(T entity)  
    {  
      using (var transaction = _context.Database.BeginTransaction()) {
        try {
          _context.Set<T>().Remove(entity);  
          transaction.Commit();
          return await _context.SaveChangesAsync();
        } catch {
          transaction.Rollback();
          return -1;
        }
      }  
    }  
  
    public virtual T Update(T t, object key)  
    {  
      using (var transaction = _context.Database.BeginTransaction()) {
        try {
          if (t == null)  
            return null;  
          T exist = _context.Set<T>().Find(key);  
          if (exist != null) {   
            _context.Entry(exist).CurrentValues.SetValues(t);  
            _context.SaveChanges(); 
            transaction.Commit(); 
          }  
          return exist; 
        } catch {
          transaction.Rollback();
          return null; 
        }
      } 
    }  
  
    public virtual async Task<T> UpdateAsyn(T t, object key)  
    { 
      using (var transaction = _context.Database.BeginTransaction()) {
        try {
          if (t == null)  
            return null;  
          T exist = await  _context.Set<T>().FindAsync(key);  
          if (exist != null)  
          {  
            _context.Entry(exist).CurrentValues.SetValues(t);  
            await _context.SaveChangesAsync(); 
            transaction.Commit(); 
          }  
          return exist;
        } catch {
          transaction.Rollback();
          return null;
        }
      }  
    }  
  
    public int Count()  
    {  
      return _context.Set<T>().Count();  
    }  
  
    public async Task<int> CountAsync()  
    {  
      return await _context.Set<T>().CountAsync();  
    }  
  
    public virtual void Save()  
    {  
      _context.SaveChanges();  
    }  
  
    public async virtual Task<int> SaveAsync()  
    {  
      return await _context.SaveChangesAsync();  
    }  
  
    public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)  
    {  
      IQueryable<T> query = _context.Set<T>().Where(predicate);  
      return query;  
    }  
  
    public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)  
    {  
      return await _context.Set<T>().Where(predicate).ToListAsync();  
    }  
  
    public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)  
    {  
  
      IQueryable<T> queryable = GetAll();  
      foreach (Expression<Func<T, object>> includeProperty in includeProperties)  
      {  
  
        queryable = queryable.Include<T, object>(includeProperty);  
      }  
  
      return queryable;  
    }  
  
    private bool disposed = false;  
    protected virtual void Dispose(bool disposing)  
    {  
      if (!this.disposed)  
      {  
        if (disposing)  
        {  
          _context.Dispose();  
        }  
        this.disposed = true;  
      }  
    }  
  
    public void Dispose()  
    {  
      Dispose(true);  
      GC.SuppressFinalize(this);  
    }  
  }  
} 