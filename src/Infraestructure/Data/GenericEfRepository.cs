using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Infraestructure.Data
{
    /// <summary>
    /// Base Generic Repository Entity FrameworkCore
    /// </summary>
    /// <typeparam name="T">Model entity</typeparam>
    /// <author>Oscar Julian Rojas</author>
    public class GenericEfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Instance WeeloDbContext BD
        /// </summary>
        protected readonly WeeloDbContext _context;
        /// <summary>
        /// Specification Evaluator to specific property search
        /// </summary>
        private readonly ISpecificationEvaluator _specificationEvaluator;

        /// <summary>
        /// Constructor GanericRepository 
        /// </summary>
        /// <param name="context">DbContext model</param>
        /// <param name="specificationEvaluator">Specificator instance</param>
        public GenericEfRepository(WeeloDbContext context, ISpecificationEvaluator specificationEvaluator)
        {
            _context = context;
            _specificationEvaluator = specificationEvaluator;
        }

        /// <summary>
        /// Add model context to create
        /// </summary>
        /// <param name="entity">Model to create</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/>Model created</returns>
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Count items list model
        /// </summary>
        /// <param name="spec">Specifitacion count model</param>
        /// <param name="cancellationToken">Cancellation model</param>
        /// <returns><typeparamref name="T"/> Quantities of the specification</returns>
        public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specification = ApplySpecification(spec);
            return await specification.CountAsync(cancellationToken);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/> Deleted model</returns>
        public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// First entity search list 
        /// </summary>
        /// <param name="spec">Specification model</param>
        /// <param name="cancellationToken">Cancellation method</param>
        /// <returns><typeparamref name="T"/> Entity model specification first</returns>
        public async Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync(cancellationToken);
        }

        /// <summary>
        /// Firts or default
        /// </summary>
        /// <param name="spec">Specification entity model</param>
        /// <param name="cancellationToken">Cancellation method</param>
        /// <returns><typeparamref name="T"/> First or default model search</returns>
        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <param name="cancellationToken">Cancellation Action Method</param>
        /// <returns><paramref name="T"/>Entity Model</returns>
        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>
        /// List Entity Model
        /// </summary>
        /// <param name="cancellationToken">Cancellation Action Method</param>
        /// <returns><typeparamref name="T"/>List Model</returns>
        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// List Async Specification model
        /// </summary>
        /// <param name="spec">Model specification</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/>List Model Specific</returns>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specification = ApplySpecification(spec);
            return await specification.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Update entity 
        /// </summary>
        /// <param name="entity">Model to update</param>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns><typeparamref name="T"/> Model updated</returns>
        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Save Changes to DB
        /// </summary>
        /// <param name="cancellationToken">Cancellation Method</param>
        /// <returns>Void Action</returns>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Apply Specification search property model
        /// </summary>
        /// <param name="spec">Property model specification</param>
        /// <param name="evaluateCriteriaOnly">Evaluate only criteria false</param>
        /// <returns>IQueryable Model entity</returns>
        protected virtual IQueryable<T> ApplySpecification(ISpecification<T> spec, bool evaluateCriteriaOnly = default)
        {
            if (spec is null) throw new ArgumentNullException("Specification is required");
            return _specificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec, evaluateCriteriaOnly);
        }

        /// <summary>
        /// Apply Specification 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="specification">specification instance model</param>
        /// <returns>IQueryable model entity</returns>
        protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            if (specification is null) throw new ArgumentNullException("Specification is required");
            if (specification.Selector is null) throw new SelectorNotFoundException();

            return _specificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}
