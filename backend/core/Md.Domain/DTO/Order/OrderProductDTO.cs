namespace Md.Domain.DTO.Order
{
    public class OrderProductDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public long? Amount { get; set; }
    }
}
