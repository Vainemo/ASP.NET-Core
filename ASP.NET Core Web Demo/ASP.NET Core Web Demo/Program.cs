namespace ASP.NET_Core_Web_Demo
{
    /// <summary>
    /// 路由格式:用来确定使用什么格式调用代码
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
            //路由逻辑,如果没有提供任何URL段,他将默认为一下模板中指定的"Home"控制器和"Index"方法
            //controller:此URL指定要运行的控制类
            //action:指定控制器类上要运行的操作方法
            //id?:针对的是路由数据
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}