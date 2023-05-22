using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASP.NET_Core_Web_Demo.Data;
using ASP.NET_Core_Web_Demo.Models;
using MvcMovie.Models;

namespace ASP.NET_Core_Web_Demo
{
    /// <summary>
    /// ·�ɸ�ʽ:����ȷ��ʹ��ʲô��ʽ���ô���
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ASPNET_Core_Web_DemoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ASPNET_Core_Web_DemoContext") ?? throw new InvalidOperationException("Connection string 'ASPNET_Core_Web_DemoContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope=app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }
                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //·���߼�,���û���ṩ�κ�URL��,����Ĭ��Ϊһ��ģ����ָ����"Home"��������"Index"����
            //controller:��URLָ��Ҫ���еĿ�����
            //action:ָ������������Ҫ���еĲ�������
            //id?:��Ե���·������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}