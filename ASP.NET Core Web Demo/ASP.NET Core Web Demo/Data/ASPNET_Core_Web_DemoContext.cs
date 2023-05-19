using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_Web_Demo.Models;

namespace ASP.NET_Core_Web_Demo.Data
{
    /// <summary>
    /// 数据库上下文类
    /// </summary>
    public class ASPNET_Core_Web_DemoContext : DbContext
    {
        public ASPNET_Core_Web_DemoContext (DbContextOptions<ASPNET_Core_Web_DemoContext> options)
            : base(options)
        {
        }

        public DbSet<ASP.NET_Core_Web_Demo.Models.Movie> Movie { get; set; } = default!;
    }
}
