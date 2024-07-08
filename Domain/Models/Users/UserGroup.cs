using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Chats;

namespace Domain.Models.Users
{
    public class UserGroup: BaseEntity<int>
    {
        public int UserId { get; set; }
        public int ChatGroupId { get; set; }

        #region Navigation Property

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        
        [ForeignKey(nameof(ChatGroupId))]
        public ChatGroup ChatGroup { get; set; }

        #endregion
    }
}