using System.Threading.Tasks;
using Domain.Models.Users;

namespace Domain.Interfaces.IUserRepositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<bool> IsExistUsername(string username);
        Task<bool> IsExistPhone(string phone);
        Task<User> LoginUserByUsernameAndPassword(string username, string password);
    }
}