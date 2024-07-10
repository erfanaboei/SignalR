using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Services.Interfaces.IChatServices;
using Application.Services.Interfaces.IUserServices;
using Application.Utilities;
using Domain.DTOs.ChatDTOs;
using Domain.Models.Chats;
using LabelPrintingEF.Domain.Utilities;
using Microsoft.AspNetCore.SignalR;

namespace E_Chat.Hubs
{
    public class ChatHub : Hub, IChatHub
    {
        private readonly IChatGroupService _chatGroupService;
        private readonly IChatService _chatService;
        private readonly IUserGroupService _userGroupService;
        
        public ChatHub(IChatGroupService chatGroupService, IChatService chatService, IUserGroupService userGroupService)
        {
            _chatGroupService = chatGroupService;
            _chatService = chatService;
            _userGroupService = userGroupService;
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Load", Context.User.GetUserId());
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string text, int groupId)
        {
            var group = _chatGroupService.GetById(groupId);
            
            var chat = new ChatDto()
            {
                Text = text,
                UserId = Context.User.GetUserId(),
                ChatGroupId = groupId,
                CreateDate = $"{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}",
                ChatGroupTitle = group.GroupTitle
            };

            _chatService.Add(chat);

            await Clients.All.SendAsync("UpdateLastMessage", chat);
            await Clients.Users(_userGroupService.GetUserIdsJoinedOnGroupByGroupId(groupId).Select(r=> r.ToString())).SendAsync("ShowNotification", chat);
            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", chat);
        }

        public async Task EnterGroup(int groupId, int currentChatId)
        {
            var group = _chatGroupService.GetDtoById(groupId);
            if (group == null) await Clients.Caller.SendAsync("Error", "گروه مورد نظر یافت نشد!");
            else
            {
                if (currentChatId > 0) await Groups.RemoveFromGroupAsync(Context.ConnectionId,currentChatId.ToString());
                await Groups.AddToGroupAsync(Context.ConnectionId, group.ChatGroupId.ToString());
                await Clients.Group(group.ChatGroupId.ToString()).SendAsync("EnterGroup", group);
            }
        }
    }
}