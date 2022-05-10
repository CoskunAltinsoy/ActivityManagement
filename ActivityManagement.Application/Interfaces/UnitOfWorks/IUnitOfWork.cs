using ActivityManagement.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IActivityRepository Activities { get; }
        ICategoryRepository Categories { get; }
        ICityRepository Cities { get; }
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        bool SaveChanges();
    }
}
