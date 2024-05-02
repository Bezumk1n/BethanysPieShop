using BethanysPieShop.Data;
using BethanysPieShop.Models;
using BethanysPieShop.Persistance;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult List(Guid categoryId)
        {
            string currentCategory = string.Empty;
            IEnumerable<Pie> pies = Enumerable.Empty<Pie>();
            if (categoryId == Guid.Empty)
            {
                currentCategory = "All pies";
                pies = _pieRepository.AllPies();
            }
            else
            {
                pies = _pieRepository
                    .AllPies()
                    .Where(q => q.CategoryId == categoryId)
                    .OrderBy(q => q.PieId);
                var category = _categoryRepository.AllCategories().FirstOrDefault(q => q.CategoryId == categoryId);
                if (category != null)
                    currentCategory = category.CategoryName;

            }
            PieListViewModel vm = PieListViewModel.Create(pies, currentCategory);
            return View(vm);
        }
        public IActionResult Details(Guid pieId) 
        { 
            var pie = _pieRepository.GetPieById(pieId);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
