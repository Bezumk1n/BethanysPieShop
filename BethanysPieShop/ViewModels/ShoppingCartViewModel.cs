using BethanysPieShop.Services;

namespace BethanysPieShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; private set; }
        public decimal ShoppingCartTotal { get; private set; }
        private ShoppingCartViewModel() { }
        public static ShoppingCartViewModel Create(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            var result = new ShoppingCartViewModel();
            result.ShoppingCart = shoppingCart;
            result.ShoppingCartTotal = shoppingCartTotal;
            return result;
        }
    }
}
