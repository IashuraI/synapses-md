using Synapsess.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Synapsess.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableQuery]
    public class CrudController<TEntity, T> : ODataController
        where TEntity : class where T : struct
    {
        protected readonly IRepository<TEntity, T> _repository;

        public CrudController(IRepository<TEntity, T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<List<TEntity>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        public virtual async Task<TEntity> GetById(T id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public virtual async Task<TEntity> Create([FromBody]TEntity tEntity)
        {
            return await _repository.Create(tEntity);
        }

        [HttpPut]
        public virtual async Task<TEntity> Update([FromBody]TEntity tEntity)
        {
            return await _repository.Update(tEntity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<T> Delete(T id)
        {
            return await _repository.Delete(id);
        }

    }
}
