using Md.Domain.Entities.Base;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Products
{
    [ODataResource]
    public sealed class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
