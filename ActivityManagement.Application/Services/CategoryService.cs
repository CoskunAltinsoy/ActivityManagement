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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IResult Add(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _unitOfWork.Categories.Delete(category);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<Category> Get(int id)
        {
            var getCategory = _unitOfWork.Categories.Get(c =>c.Id == id);
            return new SuccessDataResult<Category>(getCategory, Messages.GetCategoryId);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var getCategory = _unitOfWork.Categories.GetAll();
            return new SuccessDataResult<List<Category>>(getCategory,Messages.GetAllCategoryId);
        }

        public IResult Update(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
