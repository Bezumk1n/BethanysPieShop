using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; private set; } = Enumerable.Empty<Pie>();
        public string CurrentCategory { get; private set; } = string.Empty;
        private PieListViewModel() { }
        public static PieListViewModel Create(IEnumerable<Pie> pies, string currentCategory)
        { 
            var result = new PieListViewModel();
            result.Pies = pies;
            result.CurrentCategory = currentCategory;
            return result;
        }
    }
}
