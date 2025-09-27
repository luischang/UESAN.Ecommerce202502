using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategoriesAll()
        {
            //var context = new StoreDbContext();
            //var categories = context.Category.ToList();
            //return categories;
            return _context.Category.ToList();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context
                    .Category
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

            //return await _context
            //    .Category
            //    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> InsertCategory(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryLogic(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                category.IsActive = false;
                _context.Category.Update(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
        }

    }
}
