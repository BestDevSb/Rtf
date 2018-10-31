using System.Linq;

namespace Rtf.Data.Abstractions.DataContext
{
    /// <summary>
    /// Data context
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity class</typeparam>
        /// <returns>DbSet</returns>
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        /// <summary>
        /// Add Entity to store
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        void Add<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Save changes
        /// </summary>
        void SaveChanges();
    }
}
