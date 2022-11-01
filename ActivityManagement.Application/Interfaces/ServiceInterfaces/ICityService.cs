using ActivityManagement.Application.Utilities.Results;
using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ICityService
    {
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
        IDataResult<List<City>> GetAll();
        IDataResult<City> Get(int id);
    }
}
