namespace PetStore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;

    public class PetStoreRepository<TEntity> : IPetStoreRepository<TEntity>
        where TEntity : class
    {
        public PetStoreRepository(PetStoreContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        private DbSet<TEntity> DbSet { get; set; }

        private PetStoreContext Context { get; set; }

        public IQueryable<TEntity> All() => this.DbSet;

        public IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public Task AddAsync(TEntity entity)
        {
            return this.DbSet.AddAsync(entity).AsTask();
        }

        public Task FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
        {
            return this.DbSet.FirstOrDefaultAsync(condition);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> condition)
        {
            return this.DbSet.Where(condition);
        }

        public Task<List<TEntity>> ToListAsync()
        {
            return this.DbSet.ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
