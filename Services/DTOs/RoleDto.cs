using System;

namespace Services.DTOs
{
    public class RoleDto: BaseModelDto
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}