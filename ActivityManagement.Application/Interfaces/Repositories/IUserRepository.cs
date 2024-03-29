﻿using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        User GetByEmail(string email);  
    }
}
