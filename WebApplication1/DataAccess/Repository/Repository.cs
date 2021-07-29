using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Repository.Interface;

namespace WebApplication1.DataAccess.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll(bool trackChanges)
        {
            return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
        }

        public async Task<ICollection<T>> GetAllAsync(bool trackChanges)
        {
            return await (!trackChanges ? _context.Set<T>().AsNoTracking().ToListAsync() : _context.Set<T>().ToListAsync());
        }

        public IQueryable<T> GetByCondition(bool trackChanges, Expression<Func<T,bool>> expression)
        {
            return !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
        }

        public async Task<T> GetByConditionAsync(bool trackChanges, Expression<Func<T, bool>> expression)
        {
            return await (!trackChanges ? _context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync() : _context.Set<T>().Where(expression).FirstOrDefaultAsync());
        }

        public async Task<ICollection<T>> GetByConditionListAsync(bool trackChanges, Expression<Func<T, bool>> expression)
        {
            return await (!trackChanges ? _context.Set<T>().Where(expression).AsNoTracking().ToListAsync() : _context.Set<T>().Where(expression).ToListAsync());
        }

        public IQueryable<T> GetChildren(bool trackChanges, params Expression<Func<T, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            IQueryable<T> query = _context.Set<T>() as IQueryable<T>;

            query = properties.Aggregate(query, (current, property) => current.Include(property));

            return !trackChanges ? query.AsNoTracking() : query;
        }

        public async Task<ICollection<T>> GetChildrenAsync(bool trackChanges, params Expression<Func<T, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            IQueryable<T> query = _context.Set<T>() as IQueryable<T>;

            query = properties.Aggregate(query, (current, property) => current.Include(property));

            return await (!trackChanges ? query.AsNoTracking().ToListAsync() : query.ToListAsync());
        }

        public IQueryable<T> GetChildrenByCondition(bool trackChanges, Expression<Func<T,bool>> condition, params Expression<Func<T, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            IQueryable<T> query = _context.Set<T>() as IQueryable<T>;

            query = properties.Aggregate(query, (current, property) => current.Include(property));

            return !trackChanges ? query.AsNoTracking().Where(condition) : query.Where(condition);
        }

        public async Task<ICollection<T>> GetChildrenByConditionAsync(bool trackChanges, Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            IQueryable<T> query = _context.Set<T>() as IQueryable<T>;

            query = properties.Aggregate(query, (current, property) => current.Include(property));

            return await (!trackChanges ? query.AsNoTracking().Where(condition).ToListAsync() : query.Where(condition).ToListAsync());
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteList(ICollection<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }

        public IQueryable<T> DbRawSqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql, parameters);
        }

        public async Task DMLRawSqlQuery(string sql, params object[] parameters)
        {
            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
