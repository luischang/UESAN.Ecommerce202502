using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<User?> SignIn(string email, string password)
        {
            return await _context.User
                .Where(u => u.Email == email && u.Password == password && u.IsActive == true)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SignUp(User user)
        {
            user.IsActive = true;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
