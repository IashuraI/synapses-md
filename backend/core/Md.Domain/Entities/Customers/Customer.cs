using Md.Domain.Entities.Base;
using Md.Domain.Entities.Orders;

namespace Md.Domain.Entities.Customers
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<Order> Order { get; set; } = new List<Order>();
    }
}
