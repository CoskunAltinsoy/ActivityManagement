using ActivityManagement.Application.Utilities.Results;
using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IActivityService
    {
        IResult Add(Activity activity);
        IResult Delete(Activity activity);
        IResult Update(Activity activity);
        IDataResult<List<Activity>> GetAll();
        IDataResult<Activity> Get(int id);
    }
}
