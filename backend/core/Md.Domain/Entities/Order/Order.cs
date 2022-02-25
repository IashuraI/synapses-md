using Md.Domain.Enums;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Order
{
    [Resource]
    public sealed class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public long? DeliverymanId { get; set; }
        public decimal OrderPrice { get; set; }
        public string Street { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Entrance { get; set; } = string.Empty;
        public string Frame { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public DateTime OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public City CityId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
    }
}
