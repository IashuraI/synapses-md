using Md.Domain.Entities.Products;
using Synapsess.Infrastructure.Controllers;
using Synapsess.Infrastructure.Interfaces;

namespace Md.WebApi.Controllers
{
    public class ProductController : CrudController<Product, Guid>
    {
        public ProductController(IRepository<Product, Guid> repository) : base(repository)
        {
        }
    }
}
