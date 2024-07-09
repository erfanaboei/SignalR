using System.Collections.Generic;
using System.Linq;
using Data.Context;
using Domain.Interfaces.IChatRepositories;
using Domain.Models.Chats;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ChatRepositories
{
    public class ChatGroupRepository: Repository<ChatGroup>, IChatGroupRepository
    {
        public ChatGroupRepository(ProjectContext dbContext) : base(dbContext)
        {
        }

        public override ChatGroup GetById(int id)
        {
            return Table
                .Include(r=> r.Chats)
                .SingleOrDefault(r => r.Id == id);
        }

        public List<ChatGroup> GetAllByOwnerId(int ownerId)
        {
            return Table.Where(r => r.OwnerId == ownerId).OrderByDescending(r=> r.Id).ToList();
        }

        public List<ChatGroup> GetAllGroupsWhichUserNotMember(int userId)
        {
            return Table
                .Include(r=> r.UserGroups)
                .Where(r => r.UserGroups.All(c => c.UserId != userId))
                .ToList();
        }
    }
}