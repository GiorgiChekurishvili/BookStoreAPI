using BookStore.Entities;

namespace BookStore.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        Task<string?> UserLogin(string password, string email);
        Task<User?> UserRegistration(User user);

    }
}
