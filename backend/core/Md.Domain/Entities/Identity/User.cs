using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Identity
{
    [Resource]
    public sealed class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
