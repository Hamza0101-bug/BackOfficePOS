using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Product> GetProductbyIDAsync(int id)
        {
            try
            {
                var product = await _dataContext.Products.FindAsync(id);
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _dataContext.Products.ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
