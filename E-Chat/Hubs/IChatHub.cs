using System.Threading.Tasks;

namespace E_Chat.Hubs
{
    public interface IChatHub
    {
        Task EnterGroup(int groupId, int currentChatId);
        Task SendMessage(string text, int groupId);
    }
}