
using Domain.Core.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Abstruction.Data;

/// <summary>
/// Represent the application database context interface.
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Gets the database set for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <returns>The database set for the specified entity type.</returns>
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;

    /// <summary>
    /// Gets the entity with the specified identifier.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="id">The entity identifier.</param>
    /// <returns>The specified entity from database</returns>
    Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : Entity;

    /// <summary>
    /// Insert the specified entity into the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">the entity to be insert to the database.</param>
    void Insert<TEntity>(TEntity entity) where TEntity : Entity;

    /// <summary>
    /// Insert the specified entities into the database.
    /// </summary>
    /// <typeparam name="TEntity">The entities type.</typeparam>
    /// <param name="entities">The entities to be inserted into the database.</param>
    void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities) where TEntity : Entity;

    /// <summary>
    /// Removes the specified entity from the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">the entity to be removed.</param>
    void Remove<TEntity>(TEntity entity) where TEntity : Entity;

    /// <summary>
    /// Executes the specified SQL command asynchronous and returns the numbers of affedted rows.
    /// </summary>
    /// <param name="sql">The SQL commaned.</param>
    /// <param name="parameters">The patameters collection.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The numbers of rows affected.</returns>
    Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default);

}
