using System;
using System.Collections.Generic;

namespace Services.DTOs
{
    public class UserDto: BaseModelDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}