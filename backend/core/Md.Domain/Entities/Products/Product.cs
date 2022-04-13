using Md.Domain.Entities.Base;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Products
{
    [ODataResource]
    public sealed class Product : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public long? Amount { get; set; }
        public Category Category { get; set; } = null!;
    }
}
