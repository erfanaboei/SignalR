using Data.Context;
using Domain.Interfaces.IRoleRepositories;
using Domain.Models.Roles;

namespace Data.Repositories.RoleRepositories
{
    public class RoleRepository: Repository<Role>, IRoleRepository
    {
        public RoleRepository(ProjectContext dbContext) : base(dbContext)
        {
        }
    }
}