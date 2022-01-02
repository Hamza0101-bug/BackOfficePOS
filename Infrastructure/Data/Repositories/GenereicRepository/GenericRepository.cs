using Core.Entities;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification;
using Infrastructure.Data.SpecificationEvaluator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.GenereicRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> GetEntityAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        public async Task<bool> InsertUpdateAsync(T obj)
        {
            if(obj.Id==0)
            {
                await _dataContext.Set<T>().AddAsync(obj);
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                await _dataContext.Set<T>().AddAsync(obj);
                _dataContext.Entry(obj).State = EntityState.Modified;
            }
            await _dataContext.SaveChangesAsync();
            return true;

        }

        //  we provide specification of any <T where T is Entity or class> this function Return us Query of <T where T is Entity or class>
        private IQueryable<T> ApplySpecification(ISpecification<T> spec) 
        {
            return SpecificationEvaluator<T>.
                GetQuary(_dataContext.Set<T>().AsQueryable(), spec);
        }

        
    }
}
