using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task DeleteFavorite(int id);
        Task<Favorite?> GetFavoriteById(int id);
        Task<IEnumerable<Favorite>> GetFavorites();
        Task<int> InsertFavorite(Favorite favorite);
    }
}