using System;
using System.Collections.Generic;
using System.Linq;
using Application.Services.Interfaces.IUserServices;
using Application.Utilities;
using Domain.DTOs.ChatDTOs.ChatGroupDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Interfaces.IUserRepositories;
using Domain.Models.Users;
using LabelPrintingEF.Application.Helpers;

namespace Application.Services.Implements.UserServices
{
    public class UserGroupService: IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupService(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public List<ChatGroupListDto> GetAllByUserId(int userId)
        {
            var groups = _userGroupRepository.GetAllByUserId(userId);
            return groups.Select(r => new ChatGroupListDto()
            {
                GroupTitle = r.ChatGroup.GroupTitle,
                GroupId = r.ChatGroupId,
                LatChat = r.ChatGroup.Chats.OrderByDescending(c=> c.CreateDate).FirstOrDefault()
            }).ToList();
        }

        public RequestResult Add(UserGroupDto dto)
        {
            var model = new UserGroup()
            {
                UserId = dto.UserId,
                ChatGroupId = dto.ChatGroupId,
                CreateDate = DateTime.Now
            };

            _userGroupRepository.Add(model);
            return new RequestResult(true, RequestResultStatusCode.Success);
        }

        public List<int> GetUserIdsJoinedOnGroupByGroupId(int groupId)
        {
            return _userGroupRepository.GetUserIdsJoinedOnGroupByGroupId(groupId);
        }
    }
}