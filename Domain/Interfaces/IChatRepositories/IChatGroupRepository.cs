using System.Collections.Generic;
using Domain.Models.Chats;

namespace Domain.Interfaces.IChatRepositories
{
    public interface IChatGroupRepository: IRepository<ChatGroup>
    {
        List<ChatGroup> GetAllByOwnerId(int ownerId);
    }
}