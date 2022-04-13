using Md.Domain.Entities.Identity;

namespace Md.Domain.Entities.Base
{
    public class BaseEntity : IWithId
    {
        public Guid Id { get; set; }

        public Guid CreatedUserId { get; set; }

        public Guid? UpdatedUserId { get; set; }

        public User CreatedUser { get; set; } = null!;

        public User? UpdatedUser { get; set; }
    }
}
