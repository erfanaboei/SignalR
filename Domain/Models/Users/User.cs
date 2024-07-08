using System.Collections.Generic;
using Domain.Models.Chats;

namespace Domain.Models.Users
{
    public class User:BaseEntity<int>
    {
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        #region Navigation Property

        public ICollection<Chat> Chats { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<ChatGroup> ChatGroups { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        
        #endregion
    }
}