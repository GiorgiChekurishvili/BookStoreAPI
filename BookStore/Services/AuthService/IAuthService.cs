using BookStore.DTOs.User;

namespace BookStore.Services.AuthService
{
    public interface IAuthService
    {
        Task<string?> Login(UserLoginDTO loginDTO);
        Task<UserRegisterDTO?> Register(UserRegisterDTO registerDTO);
    }
}
