using Md.Domain.Entities.Base;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Order
{
    [Resource]
    public sealed class OrderProduct : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public long? Amount { get; set; }
        public Order Order { get; set; } = null!;
        public Product.Product Product { get; set; } = null!;
    }
}
