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
    public class ActivityRepository:RepositoryBase<Activity>,IActivityRepository
    {
        private readonly ActivityManagementDbContext _context;
        public ActivityRepository(ActivityManagementDbContext context):base(context)
        {
            _context = context;
        }

        public Activity GetByActivityCity(int id)
        {
            return _context.Activities.SingleOrDefault(a => a.CityId == id);
        }

        public Activity GetByActivityCategory(int id)
        {
            return _context.Activities.SingleOrDefault(a => a.CategoryId == id);
        }
    }
}
