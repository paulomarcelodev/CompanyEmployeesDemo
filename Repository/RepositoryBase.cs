using System.Linq.Expressions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext RepositoryContext;

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        this.RepositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        var query = RepositoryContext.Set<T>();
        return trackChanges ? query.AsNoTracking() : query;
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        var query = RepositoryContext.Set<T>().Where(expression);
        return trackChanges ? query.AsNoTracking() : query;
    }

    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}