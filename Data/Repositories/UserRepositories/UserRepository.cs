using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces.IUserRepositories;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.UserRepositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly ProjectContext _context;
        
        public UserRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsExistUsername(string username)
        {
            return await _context.Users.AnyAsync(r => r.Username == username);
        }

        public async Task<bool> IsExistPhone(string phone)
        {
            return await _context.Users.AnyAsync(r => r.Phone == phone);
        }

        public async Task<User> LoginUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(r => r.Username == username && r.Password == password);
        }
    }
}