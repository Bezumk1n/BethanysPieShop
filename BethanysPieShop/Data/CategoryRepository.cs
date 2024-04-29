using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories()
        {
            return _bethanysPieShopDbContext.Categories.OrderBy(q => q.CategoryName);
        }
    }
}
