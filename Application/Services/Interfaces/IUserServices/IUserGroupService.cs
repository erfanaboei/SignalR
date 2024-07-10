using System.Collections.Generic;
using Application.Utilities;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;
using Domain.DTOs.UserDTOs;

namespace Application.Services.Interfaces.IUserServices
{
    public interface IUserGroupService
    {
        List<ChatGroupListDto> GetAllByUserId(int userId);
        RequestResult Add(UserGroupDto dto);
        List<int> GetUserIdsJoinedOnGroupByGroupId(int groupId);
    }
}