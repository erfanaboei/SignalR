namespace Domain.DTOs.ChatDTOs
{
    public class ChatDto
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public string CreateDate { get; set; }
        public int ChatGroupId { get; set; }
    }
}