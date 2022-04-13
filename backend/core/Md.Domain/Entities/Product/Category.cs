using Md.Domain.Entities.Base;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Product
{
    [Resource]
    public sealed class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
