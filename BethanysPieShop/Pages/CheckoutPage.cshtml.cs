using BethanysPieShop.Data;
using BethanysPieShop.Models;
using BethanysPieShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BethanysPieShop.Pages
{
    public class CheckoutPageModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        public CheckoutPageModel(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            { 
                return Page();
            }

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }
            // Server side валидация полей модели (правила валидации прописаны в самой модели Order)
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutCompletePage");
            }
            return Page();
        }
    }
}
