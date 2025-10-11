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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbContext _context;

        public FavoriteRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetFavorites()
        {
            return await _context.Favorite.ToListAsync();
        }

        public async Task<Favorite?> GetFavoriteById(int id)
        {
            return await _context
                    .Favorite
                    .Include(p => p.Product)
                    .Include(u => u.User)
                    .Where(f => f.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> InsertFavorite(Favorite favorite)
        {
            await _context.Favorite.AddAsync(favorite);
            await _context.SaveChangesAsync();
            return favorite.Id;
        }

        public async Task DeleteFavorite(int id)
        {
            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite != null)
            {
                _context.Favorite.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
