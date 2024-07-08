using Application.Services.Interfaces.IUserServices;
using Domain.Interfaces.IUserRepositories;

namespace Application.Services.Implements.UserServices
{
    public class UserRoleService: IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
    }
}