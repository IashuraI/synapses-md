using Md.Domain.Interfaces;
using Md.Persistentce.Data;
using Microsoft.EntityFrameworkCore;

namespace Md.Persistentce.Services
{
    public class RepositoryEF<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly MdDbContext _productContext;
        private readonly DbSet<TEntity> _dbSet;
        public RepositoryEF(MdDbContext productContext)
        {
            _productContext = productContext;
            _dbSet = productContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> Get()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> Get(Guid id)
        {
            return (await _dbSet.FindAsync(id))!;
        }
        public async Task<TEntity> Create(TEntity tEntity)
        {
            await _dbSet.AddAsync(tEntity);
            await _productContext.SaveChangesAsync();

            return tEntity;
        }

        public async Task<TEntity> Update(TEntity tEntity)
        {
            _productContext.Entry(tEntity).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();

            return tEntity;
        }
        public async Task<Guid> Delete(Guid id)
        {
            TEntity tEntity = await Get(id);
            _dbSet.Remove(tEntity);
            await _productContext.SaveChangesAsync();

            return id;
        }
    }
}
