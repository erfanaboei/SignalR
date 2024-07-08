using Application.Services.Interfaces.IRoleServices;
using Domain.Interfaces.IRoleRepositories;

namespace Application.Services.Implements.RoleServices
{
    public class RolePermissionService: IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }
    }
}