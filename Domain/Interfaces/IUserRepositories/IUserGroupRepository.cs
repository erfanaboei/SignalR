using System.Collections.Generic;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;
using Domain.Models.Users;

namespace Domain.Interfaces.IUserRepositories
{
    public interface IUserGroupRepository: IRepository<UserGroup>
    {
        List<UserGroup> GetAllByUserId(int userId);
        List<int> GetUserIdsJoinedOnGroupByGroupId(int groupId);
    }
}