using ActivityManagement.Application.Constants;
using ActivityManagement.Application.Interfaces.Repositories;
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
    public class ActivityUserService:IActivityUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActivityUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResult Add(ActivityUser activityUser)
        {
            _unitOfWork.ActivityUsers.Add(activityUser);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ActivityUserAdded);
        }

        public IResult Delete(ActivityUser activityUser)
        {
            var activityUserGet = _unitOfWork.ActivityUsers.GetById(activityUser.Id);
            if (activityUserGet is null)
            {
                return new SuccessResult(Messages.ActivityUserNotFound);
            }
            activityUserGet.IsDeleted = true;
            _unitOfWork.ActivityUsers.Update(activityUserGet);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ActivityUserDeleted);
        }

        public IDataResult<ActivityUser> Get(int id)
        {
            var activityUserGet = _unitOfWork.ActivityUsers.Get(a => a.Id == id);
            return new SuccessDataResult<ActivityUser>(activityUserGet, Messages.ActivityUserGot);
        }

        public IDataResult<List<ActivityUser>> GetAll()
        {
            var activityUserGet = _unitOfWork.ActivityUsers.GetAll();
            return new SuccessDataResult<List<ActivityUser>>(activityUserGet,Messages.ActivityUsersGot);
        }

        public IResult Update(ActivityUser activityUser)
        {
            _unitOfWork.ActivityUsers.Update(activityUser);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ActivityUserUpdated);
        }

       
    }
}
