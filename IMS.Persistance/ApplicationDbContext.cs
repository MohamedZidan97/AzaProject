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

            // SEIF SHERIF
            builder.Entity<User_Supplier>().HasKey(us => new { us.UserId, us.SupplierId });
            builder.Entity<Customer_Product>().HasKey(cp => new { cp.CustomerId, cp.ProductId });

            builder.Entity<Customer_Product>()
                .HasOne(cp => cp.Customer)
                .WithMany()
                .HasForeignKey(cp => cp.CustomerId)
                .OnDelete(DeleteBehavior.NoAction); 
            builder.Entity<Customer_Product>()
                .HasOne(cp => cp.Product)
                .WithMany()
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Buying_Proccess>()
                .HasOne(bp => bp.application_user)
                .WithMany()
                .HasForeignKey(bp => bp.customer_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Buying_Proccess>()
                .HasOne(bp => bp.product)
                .WithMany()
                .HasForeignKey(bp => bp.product_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Buying_Proccess>()
                .HasOne(bp => bp.supplier)
                .WithMany()
                .HasForeignKey(bp => bp.supplier_id)
                .OnDelete(DeleteBehavior.NoAction);
            //

            base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }

        public DbSet<Supplier> suppliers { get; set; }

        public DbSet<StockLevel> stockLevels { get; set; }

        // SEIF SHERIF
        public DbSet<User_Supplier> user_Suppliers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Customer_Product> customer_Products { get; set; }
        public DbSet<Buying_Proccess> Buying_Proccess { get; set; }
        //
    }
}
