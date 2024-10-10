using IMS.Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(k=>k.ProductId);
            builder.Entity<Category>().HasKey(k => k.CategoryId);
            builder.Entity<StockLevel>().HasKey(k => k.StockLevelId);
            builder.Entity<Supplier>().HasKey(k => k.SupplierId);
            builder.Entity<SubCategory>().HasKey(k => k.SubCategoryId);
            //builder.Entity<SubCategory>().HasMany<Product>().WithOne()
            //    .HasPrincipalKey(x => x.SubCategoryId).HasForeignKey(x => x.SubCategoryId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Category>().HasMany<Product>().WithOne()
            //   .HasPrincipalKey(x => x.CategoryId).HasForeignKey(x => x.CategoryId)
            //   .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Category>().HasMany<SubCategory>().WithOne()
            //  .HasPrincipalKey(x => x.CategoryId).HasForeignKey(x => x.CategoryId)
            //  .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }

        public DbSet<Supplier> suppliers { get; set; }

        public DbSet<StockLevel> stockLevels { get; set; }

    }
}
