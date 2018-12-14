using Microsoft.EntityFrameworkCore;
using ModaUltimo.Models;
using System.ComponentModel.DataAnnotations;

namespace ModaUltimo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
           
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasOne<Inventory>(p => p.InventoryName)
                .WithOne(p => p.Store)
                .HasForiegnKey<Inventory>(p=>p.StoreID);
        }*/

        
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasRequired(p => p.Inventory)
                .WithOptional(p => p.Store);
            base.OnModelCreating(modelBuilder);
        }*/

         public DbSet<Store> Store { get; set; }
         public DbSet<Product> Product { get; set; }
         public DbSet<Inventory> Inventory { get; set; }
         public DbSet<Category> Category { get; set; }
    }
}