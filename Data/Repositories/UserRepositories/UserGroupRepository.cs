using System.Collections.Generic;
using System.Linq;
using Data.Context;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;
using Domain.Interfaces.IUserRepositories;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.UserRepositories
{
    public class UserGroupRepository:Repository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(ProjectContext dbContext) : base(dbContext)
        {
        }

        public List<UserGroup> GetAllByUserId(int userId)
        {
            return Table
                .Include(r=> r.ChatGroup.Chats)
                .Where(r => r.UserId == userId).ToList();
        }
    }
}