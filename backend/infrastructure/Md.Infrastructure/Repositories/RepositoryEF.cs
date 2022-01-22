using Md.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Md.Infrastructure.Repositories
{
    public class RepositoryEF<TEntity, T, TDbContext> : IRepository<TEntity, T>
        where TEntity : class where T : struct where TDbContext : DbContext
    {
        private readonly TDbContext _databaseContext;
        private readonly DbSet<TEntity> _dbSet;
        public RepositoryEF(TDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = databaseContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> Get()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> Get(T id)
        {
            return (await _dbSet.FindAsync(id))!;
        }
        public async Task<TEntity> Create(TEntity tEntity)
        {
            await _dbSet.AddAsync(tEntity);
            await _databaseContext.SaveChangesAsync();

            return tEntity;
        }

        public async Task<TEntity> Update(TEntity tEntity)
        {
            _databaseContext.Entry(tEntity).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();

            return tEntity;
        }
        public async Task<T> Delete(T id)
        {
            TEntity tEntity = await Get(id);
            _dbSet.Remove(tEntity);
            await _databaseContext.SaveChangesAsync();

            return id;
        }
    }
}
