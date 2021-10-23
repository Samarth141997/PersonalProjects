using Microsoft.EntityFrameworkCore;
using ShopBridgeApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Context
{
    //Using Entity Framework to create table in Database
    public class ProductContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        //Defining Dummy Data on Table creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product()
                    {
                        Id = 1,
                        Name = "Dark fantasy",
                        Company = "Sunfeast",
                        Description = "Chocolate filled Cookies",
                        Price = 30,
                        DateSold = new DateTime(2021, 10, 14, 10, 14, 30)
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Lays Indian Masala",
                        Company = "Lays",
                        Description = "Fried Chips flavoured with indian spices",
                        Price = 10,
                        DateSold = new DateTime(2021, 10, 15, 10, 14, 30)
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Hair Dryer",
                        Company = "Nova",
                        Description = "190 Watt Hair Dryer",
                        Price = 750,
                        DateSold = new DateTime(2021, 10, 14, 10, 14, 30)
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
