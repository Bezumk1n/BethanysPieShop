using BethanysPieShop.Models;
using BethanysPieShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies()
        {
            return _bethanysPieShopDbContext.Pies.Include(q => q.Category);
        }

        public IEnumerable<Pie> PiesOfTheWeek()
        {
            return _bethanysPieShopDbContext.Pies.Include(q => q.Category).Where(q => q.IsPieOfTheWeek);
        }

        public Pie? GetPieById(Guid pieId)
        {
            return _bethanysPieShopDbContext.Pies.FirstOrDefault(q => q.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuerry)
        {
            return _bethanysPieShopDbContext.Pies.Where(q => q.Name.ToLower().Contains(searchQuerry.ToLower()));
        }
    }
}
