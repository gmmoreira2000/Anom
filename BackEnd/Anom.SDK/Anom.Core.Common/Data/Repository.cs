using Anom.Core.Common.Data.Interfaces;
using Anom.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anom.Core.Common.Data;

public abstract class Repository : IRepository, IAggregateRoot
{
    private bool _disposed;
    private readonly DbContext _dbContext;
    
    protected Repository(DbContext context)
    {
        _dbContext = context;
    } 
    
    public DbContext Context => _dbContext;
    public string ConnectionString => Context.Database.GetDbConnection().ConnectionString;


    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        GC.SuppressFinalize(this);
        
        if (_disposed)
            return;
        
        if (disposing)
            _dbContext.Dispose();
        
        _disposed = true;
    }
}

public class Repository<T> : IRepository<T> where T: Entity, IAggregateRoot
{
    private bool _disposed;
    private readonly DbContext _dbContext;
    
    protected Repository(DbContext context)
    {
        _dbContext = context;
    } 
    
    public DbContext Context => _dbContext;
    public string ConnectionString => Context.Database.GetDbConnection().ConnectionString;
    public DbSet<T> DbSet => _dbContext.Set<T>();

    public IUnitOfWork UnitOfWork => _dbContext as IUnitOfWork;
    
    public async Task<List<T>> GetAll() => await  DbSet.ToListAsync();

    public async Task<T> GetById(Guid Id) => await DbSet.FirstOrDefaultAsync(x => x.Id == Id);

    public T Add(T entity) => DbSet.Add(entity).Entity;

    public IQueryable<T> AsQueryable() => DbSet.AsQueryable();
    
    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        GC.SuppressFinalize(this);
        
        if (_disposed)
            return;
        
        if (disposing)
            _dbContext.Dispose();
        
        _disposed = true;
    }
}