using ActivityManagement.Application.Dtos;
using ActivityManagement.Application.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        bool Register(UserForRegisterDto userForRegisterDto, string password);
        Token Login(UserForLoginDto userForLoginDto);

    }
}
