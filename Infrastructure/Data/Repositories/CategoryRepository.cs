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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IReadOnlyList<Category>> GetProductCategoryAsync()
        {
            try
            {
                var Categories = await _dataContext.Categories.ToListAsync();
                return Categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetProductCategorybyIDAsync(int id)
        {
            try
            {
                var Category = await _dataContext.Categories.FindAsync(id);
                return Category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
