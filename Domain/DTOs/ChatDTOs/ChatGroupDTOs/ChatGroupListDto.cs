using Domain.Models.Chats;

namespace Domain.DTOs.ChatDTOs.ChatGroupDTOs
{
    public class ChatGroupListDto
    {
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public Chat LatChat { get; set; }
    }
}