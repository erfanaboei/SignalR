using Data.Context;
using Domain.Interfaces.IUserRepositories;
using Domain.Models.Users;

namespace Data.Repositories.UserRepositories
{
    public class UserRoleRepository: Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ProjectContext dbContext) : base(dbContext)
        {
        }
    }
}