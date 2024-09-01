using BookStore.DTOs;

namespace BookStore.Services.AuthService
{
    public interface IAuthService
    {
        Task<string?> Login(UserLoginDTO loginDTO);
        Task<UserRegisterDTO?> Register(UserRegisterDTO registerDTO);
    }
}
