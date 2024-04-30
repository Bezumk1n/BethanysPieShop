using BethanysPieShop.Data;
using BethanysPieShop.Persistance;
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
            if(app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //app.MapDefaultControllerRoute();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // Вызываем метод наполнения БД
            DbInitializer.Seed(app);
            app.Run();
        }
    }
}
