using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Core.Abstruction.Data
{
    /// <summary>
    /// Representes the unit of work instance.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save all of the pending changes in the unit of work.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of entities that have been saved.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Begins a transaction on the current unit of work.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new database context transaction.</returns>
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
