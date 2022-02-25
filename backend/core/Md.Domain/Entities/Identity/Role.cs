using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Identity
{
    [Resource]
    public sealed class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
