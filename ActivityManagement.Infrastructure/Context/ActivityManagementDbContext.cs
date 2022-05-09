using ActivityManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Infrastructure.Context
{
    public class ActivityManagementDbContext:DbContext
    {
        public ActivityManagementDbContext(DbContextOptions<ActivityManagementDbContext> options):base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
