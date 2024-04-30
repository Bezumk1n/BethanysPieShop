namespace BethanysPieShop.Models
{
    public class ShoppingCartItem
    {
        public Guid ShoppingCartItemId { get; set; }
        public Guid PieId { get; set; }
        public Pie Pie { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
