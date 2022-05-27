using ActivityManagement.Application.Dtos;
using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Security.Hashing;
using ActivityManagement.Application.Security.Jwt;
using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Token Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userRepository
            throw new NotImplementedException();
        }

        public bool Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            User user = new User() 
            { 
                Name = userForRegisterDto.Name,
                Surname = userForRegisterDto.Surname,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = userForRegisterDto.Role
            };
            _userRepository.Add(user);
            return true;
        }
    }
}
