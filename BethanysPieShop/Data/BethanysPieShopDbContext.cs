using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data
{
    public class BethanysPieShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : base(options) { }
    }
}
