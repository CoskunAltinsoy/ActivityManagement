using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Security.Jwt
{
    public interface ITokenHelper
    {
        public Token CreateToken(User user);
    }
}
