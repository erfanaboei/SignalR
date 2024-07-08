using Application.Services.Implements.ChatServices;
using Application.Services.Implements.RoleServices;
using Application.Services.Implements.UserServices;
using Application.Services.Interfaces.IChatServices;
using Application.Services.Interfaces.IRoleServices;
using Application.Services.Interfaces.IUserServices;
using Data.Repositories;
using Data.Repositories.ChatRepositories;
using Data.Repositories.RoleRepositories;
using Data.Repositories.UserRepositories;
using Domain.Interfaces;
using Domain.Interfaces.IChatRepositories;
using Domain.Interfaces.IRoleRepositories;
using Domain.Interfaces.IUserRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatGroupService, ChatGroupService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            
            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatGroupRepository, ChatGroupRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserGroupService, UserGroupService>();
        }
    }
}