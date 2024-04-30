using BethanysPieShop.Persistance;
using BethanysPieShop.Services;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IShoppingCart shoppingCart, IPieRepository pieRepository)
        {
            _shoppingCart = shoppingCart;
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = ShoppingCartViewModel.Create(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
        public IActionResult AddToShoppingCart(Guid pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);

            if(pie != null)
                _shoppingCart.AddToCart(pie);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromShoppingCart(Guid pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);

            if (pie != null)
                _shoppingCart.RemoveFromCart(pie);
            return RedirectToAction("Index");
        }
    }
}
