using ActivityManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Infrastructure.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ActivityManagementDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("mssql")));
        }
    }
}
