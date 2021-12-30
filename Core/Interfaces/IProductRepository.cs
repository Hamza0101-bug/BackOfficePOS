using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<IReadOnlyList<Product>> GetProductsAsync(); // Get List of Products
        public Task<Product> GetProductbyIDAsync(int id); // get product by id
    }
}
