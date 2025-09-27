using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task DeleteCategory(int id);
        Task DeleteCategoryLogic(int id);
        Task<IEnumerable<Category>> GetCategories();
        IEnumerable<Category> GetCategoriesAll();
        Task<Category?> GetCategoryById(int id);
        Task<int> InsertCategory(Category category);
        Task UpdateCategory(Category category);
    }
}