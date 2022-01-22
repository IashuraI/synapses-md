namespace Md.Domain.Entities.Order
{
    public sealed class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public long? Amount { get; set; }
    }
}
