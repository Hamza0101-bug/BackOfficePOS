using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBrandRepository
    {
        public Task<IReadOnlyList<Brand>> GetProductBrandsAsync(); // Get List of Brands
        public Task<Brand> GetProductBrandbyIDAsync(int id); //Get Brand by ID
    }
}
