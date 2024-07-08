using System.Collections.Generic;
using System.Linq;
using Data.Context;
using Domain.Interfaces.IChatRepositories;
using Domain.Models.Chats;

namespace Data.Repositories.ChatRepositories
{
    public class ChatGroupRepository: Repository<ChatGroup>, IChatGroupRepository
    {
        public ChatGroupRepository(ProjectContext dbContext) : base(dbContext)
        {
        }

        public List<ChatGroup> GetAllByOwnerId(int ownerId)
        {
            return Table.Where(r => r.OwnerId == ownerId).OrderByDescending(r=> r.Id).ToList();
        }
    }
}