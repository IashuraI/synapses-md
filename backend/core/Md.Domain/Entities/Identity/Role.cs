using Md.Domain.Entities.Base;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Identity
{
    [Resource]
    public sealed class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
