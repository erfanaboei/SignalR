using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Roles;

namespace Domain.Models.Users
{
    public class UserRole: BaseEntity<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Navigation Property

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        
        #endregion
    }
}