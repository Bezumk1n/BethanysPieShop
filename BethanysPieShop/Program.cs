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
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serpviceProvider => ShoppingCart.GetCart(serpviceProvider));
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            // Включаем MVC
            builder.Services.AddControllersWithViews();
            // Включаем Razor Pages
            builder.Services.AddRazorPages();
            // Добавляем API
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Настройка игнорирования циклов
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

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

            // Для использования Razor pages
            app.MapRazorPages();
            // Для использования контроллеров (в нашем случае не нужен, так как уже используется app.MapDefaultControllerRoute())
            //app.MapControllers();

            // Вызываем метод наполнения БД
            DbInitializer.Seed(app);
            app.Run();
        }
    }
}
