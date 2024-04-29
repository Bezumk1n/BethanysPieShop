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

            // ������������ �������
            // ��� ������ � ������������� ���������� Scoped
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPieRepository, PieRepository>();

            // �������� MVC
            builder.Services.AddControllersWithViews();

            // ������������ DbContext
            builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
            });

            var app = builder.Build();

            // ��������� Middleware
            app.UseStaticFiles();
            if(app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
