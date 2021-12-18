using System;
using RtaAssignment.Core.Enums;

namespace RtaAssignment.Core.Entities
{
    public abstract class User : Entity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}