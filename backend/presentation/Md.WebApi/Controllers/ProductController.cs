using Md.Domain.Entities.Product;
using Md.Infrastructure.Controllers;
using Md.Infrastructure.Interfaces;

namespace Md.WebApi.Controllers
{
    public class ProductController : CrudController<Product, Guid>
    {
        public ProductController(IRepository<Product, Guid> repository) : base(repository)
        {
        }
    }
}
