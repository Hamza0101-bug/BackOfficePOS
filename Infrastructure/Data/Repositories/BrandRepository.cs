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
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _dataContext;
        public BrandRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Brand> GetProductBrandbyIDAsync(int id)
        {
            try
            {
                var Brand = await _dataContext.Brands.FindAsync(id);
                return Brand;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  

        public async Task<IReadOnlyList<Brand>> GetProductBrandsAsync()
        {
            try
            {
                var Brands = await _dataContext.Brands.ToListAsync();
                return Brands;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
