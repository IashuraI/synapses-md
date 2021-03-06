using Md.Domain.Entities.Orders;
using Synapsess.Infrastructure.Controllers;
using Synapsess.Infrastructure.Interfaces;

namespace Md.WebApi.Controllers
{
    public class OrderController : CrudController<Order, Guid>
    {
        public OrderController(IRepository<Order, Guid> repository) : base(repository)
        {
        }
    }
}
