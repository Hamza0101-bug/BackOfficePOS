using Core.Entities;
using Core.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id); // simple W/O spec get T type Recorde By ID
        Task<IReadOnlyList<T>> ListAllAsync(); // Get List of T type W/O Spec
        Task<T> GetEntitywithspec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync (ISpecification<T> spec);
    }
}
