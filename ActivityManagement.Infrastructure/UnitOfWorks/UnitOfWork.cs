using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Application.Interfaces.UnitOfWorks;
using ActivityManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ActivityManagementDbContext _context;
        public IActivityRepository Activities { get; }

        public ICategoryRepository Categories { get; }

        public ICityRepository Cities { get; }

        public ICompanyRepository Companies { get; }

        public IUserRepository Users { get; }
        public UnitOfWork(IActivityRepository activities, ICategoryRepository categories, ICityRepository cities,
                          ICompanyRepository companies, IUserRepository users, ActivityManagementDbContext context)
        {
            Activities = activities;
            Categories = categories;
            Cities = cities;
            Companies = companies;
            Users = users;
            _context = context;
            
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
