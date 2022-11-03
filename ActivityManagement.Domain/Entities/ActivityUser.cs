using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Domain.Entities
{
    public class ActivityUser:Entity
    {
        public int ActivitiesId { get; set; }
        public Activity Activity { get; set; }
        public int UsersId { get; set; }
        public User User { get; set; }
    }
}
