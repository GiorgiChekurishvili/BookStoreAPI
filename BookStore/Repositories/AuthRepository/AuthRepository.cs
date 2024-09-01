using BookStore.Data;
using BookStore.Entities;
using System.Security.Cryptography;

namespace BookStore.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        readonly BookStoreContext _context;
        public AuthRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<string?> UserLogin(string password, string email)
        {
            var data = await _context.Users.Where(x=>x.Email == email).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            if (VerifyPasswordHash(password, data.PasswordHash!, data.PasswordSalt!))
            {
                return "token";
            }
            return null;
            

        }

        public async Task<User?> UserRegistration(User user)
        {
            var ifexists = await _context.Users.Where(x=>x.Email == user.Email).FirstOrDefaultAsync();
            if (ifexists != null)
            {
                return null;
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedhash = System.Text.Encoding.UTF8.GetBytes(password);
                return computedhash.SequenceEqual(passwordHash);
            }
        }
    }
}
