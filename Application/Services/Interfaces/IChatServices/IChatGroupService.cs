using System.Collections.Generic;
using Application.Utilities;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Models.Chats;

namespace Application.Services.Interfaces.IChatServices
{
    public interface IChatGroupService
    {
        List<ChatGroupListDto> GetAllByOwnerId(int ownerId);
        List<ChatGroupListDto> GetAllGroupsWhichUserNotMember(int userId);
        ChatGroup GetById(int id);
        ChatGroupDto GetDtoById(int id);
        RequestResult Add(string groupName, int userId);
    }
}