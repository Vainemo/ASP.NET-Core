using ASP.NET_Core_Web_Demo.Data;
using ASP.NET_Core_Web_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ASPNET_Core_Web_DemoContext(serviceProvider.GetRequiredService<DbContextOptions<ASPNET_Core_Web_DemoContext>>())) 
        {
            //如果有值,则返回True
            if(context.Movie.Any())
            {
                return;
            }
            context.Movie.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1998-2-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M,
                Rating = "R"
            },
             new Movie
             {
                 Title = "Rio Bravo",
                 ReleaseDate = DateTime.Parse("1959-4-15"),
                 Genre = "Western",
                 Price = 3.99M,
                 Rating = "R"
             }
            ) ;
            context.SaveChanges();
        }
    }
}
