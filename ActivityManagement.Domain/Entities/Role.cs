using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Domain.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {  
        Admin,
        User,  
        Organizer,
        Company
    }
}
