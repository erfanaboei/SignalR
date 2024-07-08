using Data.Context;
using Domain.Interfaces.IChatRepositories;
using Domain.Models.Chats;

namespace Data.Repositories.ChatRepositories
{
    public class ChatRepository: Repository<Chat>, IChatRepository
    {
        public ChatRepository(ProjectContext dbContext) : base(dbContext)
        {
        }
    }
}