using Md.Domain.Entities.Base;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Meal
{
    [ODataResource]
    public sealed class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
