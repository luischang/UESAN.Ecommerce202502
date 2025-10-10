using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;
//using System.Data.StoreDbContext;


namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProductsAll()
        {
            //var context = new StoreDbContext();
            //var categories = context.Category.ToList();
            //return categories;
            return _context.Product.ToList();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context
                    .Product
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

            //return await _context
            //    .Category
            //    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> InsertProduct(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductLogic(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                product.IsActive = false;
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var productExist = await _context.Product.FindAsync(product.Id);
            if (productExist != null)
            {
                productExist.Description = product.Description;
                productExist.UnitPrice = product.UnitPrice;
                productExist.IsActive = product.IsActive;

                await _context.SaveChangesAsync();
            }           
                
        }

    }
}
