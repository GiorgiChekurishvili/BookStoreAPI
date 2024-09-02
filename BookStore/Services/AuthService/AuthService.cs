using AutoMapper;
using BookStore.DTOs;
using BookStore.Entities;
using BookStore.Repositories.AuthRepository;
using System.Security.Cryptography;

namespace BookStore.Services.AuthService
{
    public class AuthService : IAuthService
    {
        readonly IMapper _mapper;
        readonly IAuthRepository _authRepository;
        public AuthService(IMapper mapper, IAuthRepository authRepository)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }
        public async Task<string?> Login(UserLoginDTO loginDTO)
        {
            var data = await _authRepository.UserLogin(loginDTO.Password, loginDTO.Email);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<UserRegisterDTO?> Register(UserRegisterDTO registerDTO)
        {
            CreatePasswordHash(registerDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var map = _mapper.Map<User>(registerDTO);
            map.PasswordHash = passwordHash;
            map.PasswordSalt = passwordSalt;
            var user = await _authRepository.UserRegistration(map);
            if (user == null)
            {
                return null; 
            }
            return registerDTO;
            
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = System.Text.Encoding.UTF8.GetBytes(password);
            }
        }
        
    }
}
