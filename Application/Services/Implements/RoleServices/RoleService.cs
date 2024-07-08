using Application.Services.Interfaces.IRoleServices;
using Domain.Interfaces.IRoleRepositories;

namespace Application.Services.Implements.RoleServices
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
    }
}