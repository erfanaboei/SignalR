using Application.Utilities;
using Domain.DTOs.ChatDTOs;

namespace Application.Services.Interfaces.IChatServices
{
    public interface IChatService
    {
        RequestResult Add(ChatDto dto);
    }
}