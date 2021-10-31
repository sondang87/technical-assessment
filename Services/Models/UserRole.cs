using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class UserRole: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserRoleId { get; set; }

        // relationships
        [ForeignKey("UserId")]
        public User UserDetail { get; set; }
        [ForeignKey("RoleCode")]
        public Role Role { get; set; }
    }
}