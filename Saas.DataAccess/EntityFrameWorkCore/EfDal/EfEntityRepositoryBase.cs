using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Saas.DataAccess.EntityFrameWorkCore.EfDal
{
    public class EfEntityRepositoryBase<TEntity, TContext> :IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //unit of work kendisinde dahil
            using var context = new TContext();
            //gonderilen entity i context e abone ettik.ister update ister delete ne yapacaksan 
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
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
        public TEntity Get(Expression<Func<TEntity,bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
            // return context.Set<TEntity>().Where(filter).FirstOrDefault();
        }
        public List<TEntity> GetList(Expression<Func<TEntity,bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }


    }
}