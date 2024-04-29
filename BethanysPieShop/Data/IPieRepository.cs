using BethanysPieShop.Models;

namespace BethanysPieShop.Persistance
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies();
        IEnumerable<Pie> PiesOfTheWeek();
        Pie? GetPieById(Guid pieId);
    }
}
