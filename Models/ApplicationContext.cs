using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace asp_net_shop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Mock data */

            var password = "Pass1";
            var sha256 = new SHA256Managed();
            var passwordHash = Convert.ToBase64String(
                sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));

            Role[] roles = new Role[]
            {
                new Role { Id = 1, Name = "Administrator" },
                new Role { Id = 2, Name = "Client" }
            };

            User[] users = new User[]
            {
                new User { Id = 1, FullName = "Admin", Email = "admin@admin.com", Password = passwordHash, RoleId = 1 },
                new User { Id = 2, FullName = "Max Dmitriev", Email = "max@dm.com", Password = passwordHash, RoleId = 2 },
            };

            Category[] categories = new Category[]
            {
                new Category { Id = 1, Name = "Apple iPhone" },
				new Category { Id = 2, Name = "Apple iMac" },
                new Category { Id = 3, Name = "Apple Watch" },
            };

            Product[] products = new Product[]
            {
                //new Product(4, "iphone11_128gb_purple.jpeg", "Iphone 11 128gb Purple", 900),
                //new Product(5, "iphone11_128gb_black.jpeg", "Iphone 11 128gb Black", 920),
                //new Product(6, "iphone11_128gb_white.jpeg", "Iphone 11 128gb White", 940),
                //new Product(7, "iphone11_128gb_green.jpeg", "Iphone 11 128gb Green", 900),
                //new Product(8, "iphone11_128gb_purple.jpeg", "Iphone 11 128gb Purple", 900)

                new Product { Id = 1, Name = "iPhone 11 128gb Black", CategoryId = 1, Photo = "iphone11_128gb_black.jpeg", Price = 920 },
                new Product { Id = 2, Name = "iPhone 11 128gb White", CategoryId = 1, Photo = "iphone11_128gb_white.jpeg", Price = 940 },
                new Product { Id = 3, Name = "iPhone 11 128gb Green", CategoryId = 1, Photo = "iphone11_128gb_green.jpeg", Price = 900 },
                new Product { Id = 4, Name = "iMax 27\"", CategoryId = 2, Price = 1899 },
                new Product { Id = 5, Name = "Apple Watch 5", CategoryId = 3, Price = 499 },
            };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);

            base.OnModelCreating(modelBuilder);
        }
    }
}
