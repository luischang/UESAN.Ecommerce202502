using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> SignIn(string email, string password);
        Task<int> SignUp(UserCreateDTO userCreateDTO);
    }
}
