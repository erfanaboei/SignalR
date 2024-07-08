using System.Collections.Generic;
using Application.Utilities;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;

namespace Application.Services.Interfaces.IChatServices
{
    public interface IChatGroupService
    {
        List<ChatGroupListDto> GetAllByOwnerId(int ownerId);
        RequestResult Add(string groupName, int userId);
    }
}