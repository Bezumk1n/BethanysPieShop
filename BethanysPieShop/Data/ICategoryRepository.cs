using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories();
        Category? GetCategoryById(Guid id);
    }
}
