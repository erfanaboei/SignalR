using System.Collections.Generic;

namespace Domain.Models.Roles
{
    public class Role: BaseEntity<int>
    {
        public string Title { get; set; }

        #region Navigation Property

        public ICollection<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}