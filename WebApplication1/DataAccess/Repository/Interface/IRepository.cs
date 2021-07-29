using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.DataAccess.Repository.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(bool trackChanges);

        Task<ICollection<T>> GetAllAsync(bool trackChanges);

        IQueryable<T> GetByCondition(bool trackChanges, Expression<Func<T, bool>> expression);

        Task<T> GetByConditionAsync(bool trackChanges, Expression<Func<T, bool>> expression);

        Task<ICollection<T>> GetByConditionListAsync(bool trackChanges, Expression<Func<T, bool>> expression);

        IQueryable<T> GetChildren(bool trackChanges, params Expression<Func<T, object>>[] properties);

        Task<ICollection<T>> GetChildrenAsync(bool trackChanges, params Expression<Func<T, object>>[] properties);

        IQueryable<T> GetChildrenByCondition(bool trackChanges, Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] properties);

        Task<ICollection<T>> GetChildrenByConditionAsync(bool trackChanges, Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] properties);
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteList(ICollection<T> entity);

        IQueryable<T> DbRawSqlQuery<T>(string sql, params object[] parameters) where T : class;

        Task DMLRawSqlQuery(string sql, params object[] parameters);
    }
}
