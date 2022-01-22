namespace Md.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Guid id);
        Task<List<TEntity>> Get();
        Task<TEntity> Create(TEntity tEntity);
        Task<TEntity> Update(TEntity tEntity);
        Task<Guid> Delete(Guid id);
    }
}
