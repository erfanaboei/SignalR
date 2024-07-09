using System.Collections.Generic;

namespace Domain.DTOs.ChatDTOs.ChatGroupDTOs
{
    public class ChatGroupDto
    {
        public int ChatGroupId { get; set; }
        public string ChatGroupTitle { get; set; }
        public List<ChatDto> Chats { get; set; }
    }
}