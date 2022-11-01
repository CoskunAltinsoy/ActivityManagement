using ActivityManagement.Application.Constants;
using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Interfaces.UnitOfWorks;
using ActivityManagement.Application.Utilities.Results;
using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IResult Add(City city)
        {
            _unitOfWork.Cities.Add(city);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.CityAdded);
        }

        public IResult Delete(City city)
        {
            var deleteCity = _unitOfWork.Cities.GetById(city.Id);
            if (deleteCity is null)
            {
                return new SuccessResult(Messages.CityNotFound);
            }
            deleteCity.IsDeleted = true;
            _unitOfWork.Cities.Update(deleteCity);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.CityDeleted);
        }

        public IDataResult<City> Get(int id)
        {
            var getCity = _unitOfWork.Cities.Get(c => c.Id == id);
            return new SuccessDataResult<City>(getCity,Messages.CityGot);
        }

        public IDataResult<List<City>> GetAll()
        {
            var getCities = _unitOfWork.Cities.GetAll();
            return new SuccessDataResult<List<City>>(getCities,Messages.CitiesGot);
        }

        public IResult Update(City city)
        {
            _unitOfWork.Cities.Update(city);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.CityUpdated);
        }
    }
}
