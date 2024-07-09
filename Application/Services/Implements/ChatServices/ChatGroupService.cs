using System;
using System.Collections.Generic;
using System.Linq;
using Application.Services.Interfaces.IChatServices;
using Application.Services.Interfaces.IUserServices;
using Application.Utilities;
using Domain.DTOs.ChatDTOs;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Interfaces.IChatRepositories;
using Domain.Models.Chats;
using Domain.Models.Users;
using LabelPrintingEF.Application.Helpers;

namespace Application.Services.Implements.ChatServices
{
    public class ChatGroupService: IChatGroupService
    {
        private readonly IChatGroupRepository _chatGroupRepository;
        private readonly IUserGroupService _userGroupService;
        
        public ChatGroupService(IChatGroupRepository chatGroupRepository, IUserGroupService userGroupService)
        {
            _chatGroupRepository = chatGroupRepository;
            _userGroupService = userGroupService;
        }

        public List<ChatGroupListDto> GetAllByOwnerId(int ownerId)
        {
            var groups = _chatGroupRepository.GetAllByOwnerId(ownerId);
            return groups.Select(r=> new ChatGroupListDto()
            {
                GroupTitle = r.GroupTitle
            }).ToList();
        }

        public List<ChatGroupListDto> GetAllGroupsWhichUserNotMember(int userId)
        {
            var groups = _chatGroupRepository.GetAllGroupsWhichUserNotMember(userId);
            return groups.Select(r => new ChatGroupListDto()
            {
                GroupTitle = r.GroupTitle,
                GroupId = r.Id,
            }).ToList();
        }

        public ChatGroup GetById(int id)
        {
            return _chatGroupRepository.GetById(id);
        }

        public ChatGroupDto GetDtoById(int id)
        {
            var chatGroup = GetById(id);
            return new ChatGroupDto()
            {
                ChatGroupId = chatGroup.Id,
                ChatGroupTitle = chatGroup.GroupTitle,
                Chats = chatGroup.Chats.Select(r=> new ChatDto()
                {
                    UserId = r.UserId,
                    CreateDate = r.CreateDate.ToString(),
                    Text = r.ChatBody
                }).ToList()
            };  
        }

        public RequestResult Add(string groupName, int userId)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                return new RequestResult(false, RequestResultStatusCode.BadRequest, "لطفا نام گروه را وارد کنید");
            }

            var model = new ChatGroup()
            {
                OwnerId = userId,
                GroupToken = Guid.NewGuid().ToString(),
                GroupTitle = groupName,
                CreateDate = DateTime.Now
            };

            _chatGroupRepository.Add(model);

            var userGroup = new UserGroupDto()
            {
                UserId = userId,
                ChatGroupId = model.Id,
            };

            _userGroupService.Add(userGroup);
            
            return new RequestResult(true, RequestResultStatusCode.Success);
        }
    }
}