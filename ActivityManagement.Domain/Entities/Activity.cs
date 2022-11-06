using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Domain.Entities
{
    public class Activity: BaseEntity
    {
        public string ActivityName { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime ActivityDeadline { get; set; } 
        public string ActivityDescription { get; set; }
        public bool IsActive { get; set; }
        public string Quota { get; set; }
        public bool? Ticket { get; set; }
        public string? Cost { get; set; }
        public string FullAddress { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
