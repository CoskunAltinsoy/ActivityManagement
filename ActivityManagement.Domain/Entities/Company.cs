using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebSite { get; set; }
        public byte[] CompanyPasswordHash { get; set; }
        public byte[] CompanyPasswordSalt { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
