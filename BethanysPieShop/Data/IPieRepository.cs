using BethanysPieShop.Models;

namespace BethanysPieShop.Persistance
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies();
        IEnumerable<Pie> PiesOfTheWeek();
        IEnumerable<Pie> SearchPies(string searchQuerry);
        Pie? GetPieById(Guid pieId);
    }
}
