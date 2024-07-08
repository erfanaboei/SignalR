using Application.Services.Interfaces.IChatServices;
using Domain.Interfaces.IChatRepositories;

namespace Application.Services.Implements.ChatServices
{
    public class ChatService: IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
    }
}