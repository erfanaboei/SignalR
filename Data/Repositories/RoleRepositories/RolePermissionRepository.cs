using Data.Context;
using Domain.Interfaces.IRoleRepositories;
using Domain.Models.Roles;

namespace Data.Repositories.RoleRepositories
{
    public class RolePermissionRepository: Repository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(ProjectContext dbContext) : base(dbContext)
        {
        }
    }
}