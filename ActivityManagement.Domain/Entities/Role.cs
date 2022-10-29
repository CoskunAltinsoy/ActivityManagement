
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Domain.Entities
{
 
    public enum Role 
    {
        Admin = 1,
        User = 2,
        Organizer = 3,
        Company = 4
    }
}
