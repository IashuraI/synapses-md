using Md.Domain.Entities.Order;
using Md.Infrastructure.Controllers;
using Md.Infrastructure.Interfaces;

namespace Md.WebApi.Controllers
{
    public class OrderController : CrudController<Order, Guid>
    {
        public OrderController(IRepository<Order, Guid> repository) : base(repository)
        {
        }
    }
}
