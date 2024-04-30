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

            // ������������ �������
            // ��� ������ � ������������� ���������� Scoped
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPieRepository, PieRepository>();

            builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serpviceProvider => ShoppingCart.GetCart(serpviceProvider));
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            // �������� MVC
            builder.Services.AddControllersWithViews();

            var cs = builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"];
            // ������������ DbContext
            builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
            });

            var app = builder.Build();

            // ��������� Middleware
            app.UseStaticFiles();
            app.UseSession();

            if(app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.MapDefaultControllerRoute();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id:guid?}");

            // �������� ����� ���������� ��
            DbInitializer.Seed(app);
            app.Run();
        }
    }
}
