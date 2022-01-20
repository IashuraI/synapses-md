namespace Md.Domain.DTO.Product
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public long? Amount { get; set; }
    }
}
