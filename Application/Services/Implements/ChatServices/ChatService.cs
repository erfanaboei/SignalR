using System;
using Application.Services.Interfaces.IChatServices;
using Application.Utilities;
using Domain.DTOs.ChatDTOs;
using Domain.Interfaces.IChatRepositories;
using Domain.Models.Chats;
using LabelPrintingEF.Application.Helpers;

namespace Application.Services.Implements.ChatServices
{
    public class ChatService: IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public RequestResult Add(ChatDto dto)
        {
            var model = new Chat()
            {
                UserId = dto.UserId,
                ChatGroupId = dto.ChatGroupId,
                CreateDate = DateTime.Now,
                ChatBody = dto.Text,
            };

            _chatRepository.Add(model);
            return new RequestResult(true, RequestResultStatusCode.Success);
        }
    }
}