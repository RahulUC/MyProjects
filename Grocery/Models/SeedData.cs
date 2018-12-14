using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Grocery.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                
        //if data present skip
        if (context.Grocery.Any()) {
            return;
        }
        context.Grocery.AddRange(
            new Grocery { Product = "Mango", Price= 10m,IsSold = false },
            new Grocery { Product=  "Banana", Price= 20m,IsSold = true },
            new Grocery { Product = "Apple", Price= 30m,IsSold = false },
            new Grocery { Product = "orange", Price= 40m,IsSold = false },
            new Grocery { Product = "Milk", Price= 50m,IsSold = false }
        );
        context.SaveChanges();
            }
        }
    }
}