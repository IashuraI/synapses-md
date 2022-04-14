using Md.Domain.Entities.Base;
using Md.Domain.Enums;

namespace Md.Domain.Entities.Products
{
    public class ProductRecord : BaseEntity
    {
        public decimal Price { get; set; }
        public long Amount { get; set; }
        public AmountType AmountType { get; set; }
    }
}
