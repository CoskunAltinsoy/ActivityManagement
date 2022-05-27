using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public User GetByEmail(string email)
        {
            return _userRepository.Get(u => u.Email == email).First();
        }
    }
}
