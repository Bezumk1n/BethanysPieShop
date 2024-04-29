using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=Guid.NewGuid(), CategoryName="Fruit pies", Description="All-fruity pies"},
                new Category{CategoryId=Guid.NewGuid(), CategoryName="Cheese cakes", Description="Cheesy all the way"},
                new Category{CategoryId=Guid.NewGuid(), CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pie"}
            };
    }
}
