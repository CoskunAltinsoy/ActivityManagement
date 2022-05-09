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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ActivityManagementDbContext context) : base(context)
        {
        }
    }
}
