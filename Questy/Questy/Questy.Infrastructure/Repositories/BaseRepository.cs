using Microsoft.EntityFrameworkCore;
using Questy.Data;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public QuestyContext RepoContext { get; set; }

        public BaseRepository(QuestyContext repositoryContext)
        {
            RepoContext = repositoryContext;
        }

        public T Create(T entity)
        {
            RepoContext.Set<T>().AddAsync(entity);
            RepoContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            RepoContext.Set<T>().Remove(entity);
            RepoContext.SaveChangesAsync();
        }

        public IQueryable<T> FindAll()
        {
            return RepoContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepoContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            RepoContext.Set<T>().Update(entity);
            RepoContext.SaveChangesAsync();
            return entity;
        }
    }
}
