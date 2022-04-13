using Md.Domain.Entities.Base;
using Md.Domain.Entities.Delivery;
using Md.Domain.Entities.Customers;
using Md.Domain.Entities.Location;
using Md.Domain.Enums;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Order
{
    [ODataResource]
    public sealed class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid AddressFromId { get; set; }
        public Guid AddressToId { get; set; }
        public Guid? DeliveryManId { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DeliveryMan? DeliveryMan { get; set; }
        public Customer Customer { get; set; } = null!;
        public Address AddressFrom { get; set; } = null!;
        public Address AddressTo { get; set; } = null!;
    }
}
