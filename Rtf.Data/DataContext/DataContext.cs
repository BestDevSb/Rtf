using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rtf.Data.DataContext
{
    using Abstractions.DataContext;
    using Model;

    /// <summary>
    /// DataContext
    /// </summary>
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        
        /// <summary>
        /// User credentials
        /// </summary>
        public DbSet<UserCredentials> Credentials { get; set; }

        /// <summary>
        /// Feedbacks
        /// </summary>
        public DbSet<FeedBack> FeedBacks { get; set; }

        /// <summary>
        /// Rate categories
        /// </summary>
        public DbSet<RateCategory> RateCategories { get; set; }

        IQueryable<TEntity> IDataContext.Query<TEntity>()
        {
            return Set<TEntity>();
        }

        void IDataContext.Add<TEntity>(TEntity entity)
        {
            Set<TEntity>().Add(entity);
        }

        void IDataContext.SaveChanges()
        {
            SaveChanges();
        }    
    }
}
