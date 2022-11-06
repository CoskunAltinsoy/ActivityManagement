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
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IResult Add(Activity activity)
        {
            _unitOfWork.Activities.Add(activity);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ActivityAdded);
        }

        public IResult Delete(Activity activity)
        {
            var deleteActivity = _unitOfWork.Activities.GetById(activity.Id);
            if (deleteActivity is null)
            {
                return new SuccessResult(Messages.ActivityNotFound);
            }
            if (!CheckActivityTime(activity.Id))
            {
                return new SuccessResult(Messages.LessThanFiveDays);
            }
            deleteActivity.IsDeleted = true;
            _unitOfWork.Activities.Update(deleteActivity);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ActivityDeleted);
        }

        public IDataResult<Activity> Get(int id)
        {
            var getActivity = _unitOfWork.Activities.Get(a => a.Id == id);
            return new SuccessDataResult<Activity>(getActivity, Messages.ActivityGot);
        }

        public IDataResult<List<Activity>> GetAll()
        {
            var getActivity = _unitOfWork.Activities.GetAll();
            return new SuccessDataResult<List<Activity>>(getActivity, Messages.ActivitiesGot);
        }

        public IResult Update(Activity activity)
        {
            if (!CheckActivityTime(activity.Id))
            {
                return new SuccessResult(Messages.LessThanFiveDays);
            }
            _unitOfWork.Activities.Update(activity);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ActivityUpdated);
        }

        private bool CheckActivityTime(int id)
        {
            Activity activity = _unitOfWork.Activities.GetById(id);
            DateTime time = DateTime.Now;
            activity.ActivityDeadline = Convert.ToDateTime(activity.ActivityDate - time);
            if (activity.ActivityDeadline.Day < 5)
            {
                return false;
            }
            return true;

        }
    }
}
