using ActivityManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Utilities.Attributes
{
    public class AuthorizeRolesAttribute: AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Role[] allowedRoles)
        {
            var allowedRolesAsString = allowedRoles.Select(x => Enum.GetName(typeof(Role),x));
            Roles = allowedRolesAsString.ToString();

        }
    }
}
