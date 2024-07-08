using Domain.Models.Chats;

namespace Domain.DTOs.ChatDTOs.ChatGroupDTOs
{
    public class ChatGroupListDto
    {
        public string GroupTitle { get; set; }
        public Chat LatChat { get; set; }
    }
}