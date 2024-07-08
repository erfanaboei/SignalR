using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Users;

namespace Domain.Models.Chats
{
    public class ChatGroup:BaseEntity<int>
    {
        public int OwnerId { get; set; }
        public string GroupTitle { get; set; }
        public string GroupToken { get; set; }
        
        #region Navigation Property

        [ForeignKey(nameof(OwnerId))]
        public User User { get; set; }

        public ICollection<Chat> Chats { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        
        #endregion
    }
}