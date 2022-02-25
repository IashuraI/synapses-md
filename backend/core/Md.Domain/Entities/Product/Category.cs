using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Product
{
    [Resource]
    public sealed class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
