using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}
