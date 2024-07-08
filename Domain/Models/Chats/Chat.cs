using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Users;

namespace Domain.Models.Chats
{
    public class Chat: BaseEntity<int>
    {
        public string ChatBody { get; set; }
        public int UserId { get; set; }
        public int? ChatGroupId { get; set; }
        
        #region Navigation Property

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(ChatGroupId))]
        public ChatGroup ChatGroup { get; set; }
        
        #endregion
    }
}