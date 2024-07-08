using System.Threading.Tasks;
using Application.Utilities;
using Domain.DTOs.AccountDTOs;

namespace Application.Services.Interfaces.IUserServices
{
    public interface IUserService
    {
        Task<bool> IsExistUsername(string username);
        Task<bool> IsExistPhone(string phone);
        Task<RequestResult> RegisterUser(RegisterDto dto);
        Task<RequestResult> LoginUser(LoginDto dto);
    }
}