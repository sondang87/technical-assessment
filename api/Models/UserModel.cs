using System;
using System.Collections.Generic;

namespace api.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsDel { get; set; }
        public string UserType { get; set; }

        // relationships
        public Guid TenantId { get; set; }
        public Guid? CustomerId { get; set; }
        public List<string> UserRoles { get; set; }

        //extra
    }
}