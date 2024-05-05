using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
