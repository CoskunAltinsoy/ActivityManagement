using ActivityManagement.Application.Utilities.Results;
using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IActivityUserService
    {
        IResult Add(ActivityUser activityUser);
        IResult Delete(ActivityUser activityUser);
        IResult Update(ActivityUser activityUser);
        IDataResult<List<ActivityUser>> GetAll();
        IDataResult<ActivityUser> Get(int id);
  
    }
}
