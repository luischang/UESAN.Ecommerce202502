using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> SignIn(string email, string password);
        Task<int> SignUp(User user);
    }
}
