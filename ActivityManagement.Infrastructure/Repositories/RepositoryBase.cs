using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Domain.Entities;
using ActivityManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(ActivityManagementDbContext context)
        {
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public List<T> Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).Where(g => g.IsDeleted == false).ToList();
        }

        public List<T> GetAll()
        {
            return _dbSet.Where(g => g.IsDeleted == false).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.AsNoTracking().Where(t => t.IsDeleted == false).SingleOrDefault(p => p.Id == id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
