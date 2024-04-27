using BethanysPieShop.Data;
using BethanysPieShop.Persistance;

namespace BethanysPieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ������������ �������
            // ��� ������ � ������������� ���������� Scoped
            builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
            builder.Services.AddScoped<IPieRepository, MockPieRepository>();

            // �������� MVC
            builder.Services.AddControllersWithViews();

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
