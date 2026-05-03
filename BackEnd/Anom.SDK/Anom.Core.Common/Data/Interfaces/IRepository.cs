using Anom.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anom.Core.Common.Data.Interfaces;

public interface IRepository : IAggregateRoot, IDisposable
{
    protected DbContext Context { get; }
    protected string ConnectionString { get; }
}

public interface IRepository<T> : IDisposable where T : Entity, IAggregateRoot
{
    protected DbContext Context { get; }
    protected string ConnectionString { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public Task<List<T>> GetAll();
    public Task<T> GetById(Guid Id);
    public T Add(T entity);
    public IQueryable<T> AsQueryable();
}