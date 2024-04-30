using BethanysPieShop.Data;
using BethanysPieShop.Persistance;
using BethanysPieShop.Services;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Регистрируем сервисы
            // Для работы с репозиториями используем Scoped
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPieRepository, PieRepository>();

            builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serpviceProvider => ShoppingCart.GetCart(serpviceProvider));
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            // Включаем MVC
            builder.Services.AddControllersWithViews();

            var cs = builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"];
            // Регистрируем DbContext
            builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
            });

            var app = builder.Build();

            // Добавляем Middleware
            app.UseStaticFiles();
            app.UseSession();

            if(app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.MapDefaultControllerRoute();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id:guid?}");

            // Вызываем метод наполнения БД
            DbInitializer.Seed(app);
            app.Run();
        }
    }
}
