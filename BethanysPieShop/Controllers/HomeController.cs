using BethanysPieShop.Persistance;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            HomeViewModel vm = HomeViewModel.Create(_pieRepository.PiesOfTheWeek());
            return View(vm);
        }
    }
}
