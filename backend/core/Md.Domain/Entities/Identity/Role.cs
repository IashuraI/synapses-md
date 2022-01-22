﻿namespace Md.Domain.Entities.Identity
{
    public sealed class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
