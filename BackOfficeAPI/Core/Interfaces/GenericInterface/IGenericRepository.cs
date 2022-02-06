using Core.Entities;
using Core.Interfaces.Specification;

namespace Core.Interfaces.GenericInterface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
    
        Task<T> GetEntityAsync(ISpecification<T> spec); // interface
        Task<IReadOnlyList<T>> ListAsync (ISpecification<T> spec); // 
        Task<int> CountAsync (ISpecification<T> spec);
        Task<bool> InsertUpdateAsync(T obj);
    }
}
