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
                new Category { Id = 1, Name = "Apple iPhone", Photo = "iphones.png" },
				new Category { Id = 2, Name = "Apple iMac", Photo = "imac.jpg" },
                new Category { Id = 3, Name = "Apple iWatch", Photo = "iwatch.jpg" },
                new Category { Id = 4, Name = "Apple iPad", Photo = "ipads.jpg" },
            };

            Product[] products = new Product[]
            {
                new Product { Id = 1, Name = "iPhone 11 128gb Black", CategoryId = 1, Photo = "iphone11_128gb_black.jpeg", Price = 920 },
                new Product { Id = 2, Name = "iPhone 11 128gb White", CategoryId = 1, Photo = "iphone11_128gb_white.jpeg", Price = 940 },
                new Product { Id = 3, Name = "iPhone 11 128gb Green", CategoryId = 1, Photo = "iphone11_128gb_green.jpeg", Price = 900 },
                new Product { Id = 4, Name = "iPhone 11 128gb Purple", CategoryId = 1, Photo = "iphone11_128gb_purple.jpeg", Price = 900 },
                new Product { Id = 5, Name = "iMac 27\" i7 512Gb 2020", CategoryId = 2, Photo = "imac.jpg", Price = 2999, Description = "Экран 27\" IPS Retina (5120x2880) 5K LED / Intel Core i7 (3.8 - 5.0 ГГц) / RAM 8 ГБ / SSD 512 ГБ / AMD Radeon Pro 5500 XT, 8 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / кардридер / веб-камера / macOS Catalina / 8.92 кг / серебристый / клавиатура + мышь" },
                new Product { Id = 6, Name = "iMac 24\" М1 4.5К 7‑ядер GPU 256GB Blue", CategoryId = 2, Photo = "imac24.jpg", Price = 1999, Description = "Экран 23.5\" (4480x2520) 4.5K / Apple M1 / RAM 8 ГБ / SSD 256 ГБ / Apple M1 Graphics (7 ядер) / без ОД / Wi-Fi / Bluetooth / веб-камера / macOS Big Sur / 4.46 кг / синий / клавиатура + мышь" },
                new Product { Id = 7, Name = "iWatch Series 6 GPS 44mm Blue Aluminium Case with Deep Navy Sport Band", CategoryId = 3, Photo = "iwatchblue6.jpg", Price = 499 },
                new Product { Id = 8, Name = "iWatch SE GPS 40mm Silver Aluminium Case with White Sport Band", CategoryId = 3, Photo = "iwatchwhite6.jpg", Price = 399 },
                new Product { Id = 9, Name = "iWatch SE GPS 40mm Silver Aluminium Case with White Sport Band", CategoryId = 3, Photo = "iwatchblack6.jpg", Price = 449 },
                new Product { Id = 10, Name = "iPad 10.2\" Wi-Fi 32GB Space Gray 2020", CategoryId = 4, Photo = "ipad10_2_gray.jpg", Price = 449 },
                new Product { Id = 11, Name = "iPad Air 10.9\" Wi-Fi 64GB Space Gray", CategoryId = 4, Photo = "ipad_air_gray_10_9.jpg", Price = 799 },
                new Product { Id = 12, Name = "iPad Pro 11\" M1 Wi-Fi + Cellular 128GB Space Gray", CategoryId = 4, Photo = "ipad_pro_11_gray.jpg", Price = 1499 },
                new Product { Id = 13, Name = "iPad Air 10.9\" Wi-Fi + Cellular 64GB Sky Blue", CategoryId = 4, Photo = "ipad_air_10_9_blue.jpg", Price = 1199 },
            };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);

            base.OnModelCreating(modelBuilder);
        }
    }
}
