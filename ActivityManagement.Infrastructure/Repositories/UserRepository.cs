using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Domain.Entities;
using ActivityManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ActivityManagementDbContext _context;
        public UserRepository(ActivityManagementDbContext context):base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u=>u.Email == email);
        }
    }
}
