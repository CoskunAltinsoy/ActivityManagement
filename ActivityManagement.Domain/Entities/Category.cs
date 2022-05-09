using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Domain.Entities
{
    public class Category:BaseEntity
    {    
        public string CategoryName { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
