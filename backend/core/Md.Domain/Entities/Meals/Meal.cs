using Md.Domain.Entities.Base;
using Md.Domain.Entities.Products;

namespace Md.Domain.Entities.Meals
{
    public class Meal : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public Category Category { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
