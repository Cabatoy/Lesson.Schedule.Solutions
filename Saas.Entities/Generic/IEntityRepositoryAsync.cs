using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Entities.Generic
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// t refarans tipinde olmali Ientityden 
    /// implemente edilis newlenebilir 
    /// her sey gonderilebilir buraya</typeparam>
    public interface IEntityRepositoryAsync<T> where T : class, IEntity, new()
    {
        //T Add(T t);
        Task<T> AddAsyn(T t);
        //int Count();
        Task<int> CountAsync();
        //void Delete(T entity);
        Task<int> DeleteAsyn(T entity);
        void Dispose();
        //T Find(Expression<Func<T,bool>> match);
        //ICollection<T> FindAll(Expression<Func<T,bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T,bool>> match);
        Task<T> FindAsync(Expression<Func<T,bool>> match);
        //IQueryable<T> FindBy(Expression<Func<T,bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T,bool>> predicate);
        //T Get(int id);
        //IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        //IQueryable<T> GetAllIncluding(params Expression<Func<T,object>>[] includeProperties);
        Task<T> GetAsync(int id);
        //void Save();
        Task<int> SaveAsync();
        //T Update(T t,object key);
        Task<T> UpdateAsyn(T t,object key);
      
    }
}
