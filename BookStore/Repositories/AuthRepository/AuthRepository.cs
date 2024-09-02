using BookStore.Data;
using BookStore.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BookStore.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        readonly BookStoreContext _context;
        readonly IConfiguration _config;
        public AuthRepository(BookStoreContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task<string?> UserLogin(string password, string email)
        {
            var data = await _context.Users.Include(x=>x.Role).Where(x=>x.Email == email).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            if (VerifyPasswordHash(password, data.PasswordHash!, data.PasswordSalt!))
            {
                var token = CreateToken(data);
                return token;
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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedhash = System.Text.Encoding.UTF8.GetBytes(password);
                return computedhash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name!),

                new Claim(ClaimTypes.Surname, user.Surname!),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role!.Name),

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
