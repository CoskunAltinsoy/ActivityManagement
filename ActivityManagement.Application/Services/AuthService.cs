using ActivityManagement.Application.Constants;
using ActivityManagement.Application.Dtos;
using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Interfaces.UnitOfWorks;
using ActivityManagement.Application.Security.Hashing;
using ActivityManagement.Application.Security.Jwt;
using ActivityManagement.Application.Utilities.Results;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenHelper _tokenHelper;
        public AuthService(IUserRepository userRepository, IUnitOfWork unitOfWork, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _unitOfWork.Users.GetByEmail(userForLoginDto.Email);
            if (userToCheck is null)
            {
                return new ErrorDataResult<User>(Messages.EmailHasNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.IncorrectPassword);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.UserLoggedin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
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
            //_userRepository.Add(user);
            _unitOfWork.Users.Add(user);
            _unitOfWork.SaveChanges();
            return new SuccessDataResult<User>(user, Messages.UserResgistered);
        }

        public IResult CheckIfUserExist(string email)
        {
            var checkEmail = this._userRepository.GetByEmail(email);
            if (checkEmail is not null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<Token> CreateAccessToken(User user)
        {
            var token = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<Token>(token,"Token created");
        }
    }
}
