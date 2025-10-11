using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task DeleteFavorite(int id);
        Task<FavoriteDetailDTO> GetFavoriteById(int id);
        Task<IEnumerable<FavoriteDetailDTO>> GetFavorites();
        Task<int> InsertFavorite(FavoriteCreateDTO favoriteCreateDTO);
    }
}