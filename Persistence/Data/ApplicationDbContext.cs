
using Application.Core.Abstruction.Common;
using Application.Core.Abstruction.Data;
using Domain.Core.Base;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Persistence.Data;

/// <summary>
/// Represents the applications database context.
/// </summary>
public class ApplicationDbContext : DbContext, IDbContext, IUnitOfWork 
{
    private readonly IDateTime _dateTime;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> calss.
    /// </summary>
    /// <param name="options">The database context options</param>
    /// <param name="dateTime">The current date and time.</param>
    /// <param name="mediator">The mediator.</param>
    public ApplicationDbContext(DbContextOptions options, IDateTime dateTime, IMediator mediator) : base(options)
    {
        _dateTime = dateTime;
        _mediator = mediator;
    }

    /// <inheritdoc />
    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity 
        => base.Set<TEntity>();
    

    /// <inheritdoc />
    public async Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : Entity
        => id == Guid.Empty ?
            throw new NullReferenceException() :
            await Set<TEntity>().FindAsync(id) ?? throw new NullReferenceException();
    

    /// <inheritdoc />
    public void Insert<TEntity>(TEntity entity) where TEntity : Entity 
        => Set<TEntity>().Add(entity);
   

    /// <inheritdoc />
    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities) where TEntity : Entity 
        => Set<TEntity>().AddRange(entities);
    

    /// <inheritdoc />
    void IDbContext.Remove<TEntity>(TEntity entity) 
        => Set<TEntity>().Remove(entity);
    

    /// <inheritdoc />
    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default) 
        => Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);

    /// <summary>
    /// Save all of the pending changes in the unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellationToken.</param>
    /// <returns>The number of entities that have been saved.</returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        DateTime utcNow = _dateTime.UtcNow;

        return base.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />   
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken) 
        => Database.BeginTransactionAsync(cancellationToken);

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // modelBuilder.ApplyUtcDateTimeConverter();

        base.OnModelCreating(modelBuilder);
    }








}
