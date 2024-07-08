using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models.Roles
{
    public class RolePermission:BaseEntity<int>
    {
        public int RoleId { get; set; }
        public PermissionEnum Permission { get; set; }

        #region Navigation Property

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        #endregion
    }
}