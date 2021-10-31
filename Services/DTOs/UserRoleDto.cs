using System;

namespace Services.DTOs
{
    public class UserRoleDto: BaseModelDto
    {
        public Guid UserRoleId { get; set; }

        // relationships
        public UserDto UserDetail { get; set; }
        public RoleDto Role { get; set; }
    }
}