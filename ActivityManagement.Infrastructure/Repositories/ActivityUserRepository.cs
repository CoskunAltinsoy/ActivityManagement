using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Domain.Entities;
using ActivityManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Infrastructure.Repositories
{
    public class ActivityUserRepository : RepositoryBase<ActivityUser>, IActivityUserRepository
    {
        private readonly ActivityManagementDbContext _context;
        public ActivityUserRepository(ActivityManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public bool AddUserToActivity(int activityId, int userId)
        {
            var activity = _context.Activities.Where(a => a.Id == activityId)
                .Include(u => u.Users).First();

            var user = _context.Users.Where(u => u.Id == userId).First();
            activity.Users.Add(user);

            return _context.SaveChanges() > 0;
        }

        public Activity GetActivityUser(int activityId)
        {
            return _context.Activities.Where(a => a.Id == activityId)
               .Include(u => u.Users).First(); 
        }
  
    }
}
