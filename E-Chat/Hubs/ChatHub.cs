using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Services.Interfaces.IChatServices;
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
        public ChatHub(IChatGroupService chatGroupService, IChatService chatService)
        {
            _chatGroupService = chatGroupService;
            _chatService = chatService;
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
            var chat = new ChatDto()
            {
                Text = text,
                UserId = Context.User.GetUserId(),
                ChatGroupId = groupId,
                CreateDate = $"{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}",
            };

            _chatService.Add(chat);

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