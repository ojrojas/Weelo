using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Weelo.Core.Interfaces
{
    /// <summary>
    /// Repository Async Methods 
    /// </summary>
    /// <typeparam name="T">Entity Model</typeparam>
    public interface IAsyncRepository<T>
    {
        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <param name="cancellationToken">Cancellation Action Method</param>
        /// <returns><paramref name="T"/>Entity Model</returns>
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// List Entity Model
        /// </summary>
        /// <param name="cancellationToken">Cancellation Action Method</param>
        /// <returns><typeparamref name="T"/>List Model</returns>
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// List Async Specification model
        /// </summary>
        /// <param name="spec">Model specification</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/>List Model Specific</returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add model context to create
        /// </summary>
        /// <param name="entity">Model to create</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/>Model created</returns>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update entity 
        /// </summary>
        /// <param name="entity">Model to update</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/> Model updated</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/> Deleted model</returns>
        Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count items list model
        /// </summary>
        /// <param name="spec">Specifitacion count model</param>
        /// <param name="cancellationToken">Cancellation model</param>
        /// <returns><typeparamref name="T"/> Quantities of the specification</returns>
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// First entity search list 
        /// </summary>
        /// <param name="spec">Specification model</param>
        /// <param name="cancellationToken">Cancellation method</param>
        /// <returns><typeparamref name="T"/> Entity model specification first</returns>
        Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// Firts or default
        /// </summary>
        /// <param name="spec">Specification entity model</param>
        /// <param name="cancellationToken">Cancellation method</param>
        /// <returns><typeparamref name="T"/> First or default model search</returns>
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    }
}
