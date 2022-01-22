namespace Md.Infrastructure.Interfaces
{
    public interface IRepository<TEntity, T> 
        where TEntity : class where T : struct
    {
        Task<TEntity> Get(T id);
        Task<List<TEntity>> Get();
        Task<TEntity> Create(TEntity tEntity);
        Task<TEntity> Update(TEntity tEntity);
        Task<T> Delete(T id);
    }
}
