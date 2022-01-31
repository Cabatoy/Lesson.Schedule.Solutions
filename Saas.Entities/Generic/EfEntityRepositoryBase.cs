using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.Entities.Generic;

public class EfEntityRepositoryBase<TEntity, TContext> :IEntityRepository<TEntity>, IEntityRepositoryAsync<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    #region sync

    public void Add(TEntity entity)
    {
        //unit of work kendisinde dahil
        using var context = new TContext();
        var addedcontext = context.Entry(entity);
        addedcontext.State = EntityState.Added;
        var ss = context.SaveChanges();//  SaveChanges();
        //gonderilen entity i context e abone ettik.
        //ister update ister delete ne yapacaksan 
    }

    public void Delete(TEntity entity)
    {
        using var context = new TContext();
        //gonderilen entity i context e abone ettik.ister update ister delete ne yapacaksan 
        var deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var context = new TContext();
        //gonderilen entity i context e abone ettik.ister update ister delete ne yapacaksan 
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        context.SaveChanges();
    }
    public TEntity? Get(Expression<Func<TEntity,bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter);
        // return context.Set<TEntity>().Where(filter).FirstOrDefault();
    }
    public List<TEntity> GetList(Expression<Func<TEntity,bool>>? filter = null)
    {
        using var context = new TContext();
        return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
    }

    #endregion

    #region async

    public virtual IQueryable<TEntity> GetAll()
    {
        using var _context = new TContext();
        return _context.Set<TEntity>();
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        using var _context = new TContext();
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> GetAsync(int id)
    {
        using var _context = new TContext();
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsyn(TEntity t)
    {
        using var _context = new TContext();
        _context.Set<TEntity>().Add(t);
        await _context.SaveChangesAsync();
        return t;

    }

    public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity,bool>> match)
    {
        using var _context = new TContext();
        return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
    }

    public virtual async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity,bool>> match)
    {
        using var _context = new TContext();
        return await _context.Set<TEntity>().Where(match).ToListAsync();
    }

    public virtual async Task<int> DeleteAsyn(TEntity entity)
    {
        using var _context = new TContext();
        _context.Set<TEntity>().Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity> UpdateAsyn(TEntity t,object key)
    {
        using var _context = new TContext();
        if (t == null)
            return null;
        TEntity exist = await _context.Set<TEntity>().FindAsync(key);
        if (exist != null)
        {
            _context.Entry(exist).CurrentValues.SetValues(t);
            await _context.SaveChangesAsync();
        }
        return exist;
    }


    public virtual async Task<int> CountAsync()
    {
        using var _context = new TContext();
        return await _context.Set<TEntity>().CountAsync();
    }

    public virtual async Task<int> SaveAsync()
    {
        using var _context = new TContext();
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity,bool>> predicate)
    {
        using var _context = new TContext();
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    //alternatif kullanim bicimi
    //public virtual async Task<TEntity?> GetById(int id)
    //{
    //    using var _context = new TContext();
    //    DbSet<TEntity> dbSet = _context.Set<TEntity>();
    //    return await dbSet.FindAsync(id);
    //}
  
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        using var _context = new TContext();
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
    #endregion


}
