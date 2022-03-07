using System.Linq.Expressions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext _repositoryContext;

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        var query = _repositoryContext.Set<T>();
        return trackChanges ? query.AsNoTracking() : query;
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        var query = _repositoryContext.Set<T>().Where(expression);
        return trackChanges ? query.AsNoTracking() : query;
    }

    public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

    public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
}