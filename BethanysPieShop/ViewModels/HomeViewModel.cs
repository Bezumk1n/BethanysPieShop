using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; private set; } = Enumerable.Empty<Pie>();
        private HomeViewModel() { }
        public static HomeViewModel Create(IEnumerable<Pie> piesOfTheWeek)
        {
            var result = new HomeViewModel();
            result.PiesOfTheWeek = piesOfTheWeek;
            return result;
        }
    }
}
