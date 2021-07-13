﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asp_net_shop.Models;

namespace asp_net_shop.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210713072722_image-urls")]
    partial class imageurls
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("asp_net_shop.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 2,
                            Quantity = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("asp_net_shop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apple iPhone",
                            Photo = "/img/iphones.png"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Apple iMac",
                            Photo = "/img/imac.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Apple iWatch",
                            Photo = "/img/iwatch.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Apple iPad",
                            Photo = "/img/ipads.jpg"
                        });
                });

            modelBuilder.Entity("asp_net_shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb Black",
                            Photo = "/img/iphone11_128gb_black.jpeg",
                            Price = 920
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb White",
                            Photo = "/img/iphone11_128gb_white.jpeg",
                            Price = 940
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb Green",
                            Photo = "/img/iphone11_128gb_green.jpeg",
                            Price = 900
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb Purple",
                            Photo = "/img/iphone11_128gb_purple.jpeg",
                            Price = 900
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Экран 27\" IPS Retina (5120x2880) 5K LED / Intel Core i7 (3.8 - 5.0 ГГц) / RAM 8 ГБ / SSD 512 ГБ / AMD Radeon Pro 5500 XT, 8 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / кардридер / веб-камера / macOS Catalina / 8.92 кг / серебристый / клавиатура + мышь",
                            Name = "iMac 27\" i7 512Gb 2020",
                            Photo = "/img/imac.jpg",
                            Price = 2999
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Экран 23.5\" (4480x2520) 4.5K / Apple M1 / RAM 8 ГБ / SSD 256 ГБ / Apple M1 Graphics (7 ядер) / без ОД / Wi-Fi / Bluetooth / веб-камера / macOS Big Sur / 4.46 кг / синий / клавиатура + мышь",
                            Name = "iMac 24\" М1 4.5К 7‑ядер GPU 256GB Blue",
                            Photo = "/img/imac24.jpg",
                            Price = 1999
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Name = "iWatch Series 6 GPS 44mm Blue Aluminium Case with Deep Navy Sport Band",
                            Photo = "/img/iwatchblue6.jpg",
                            Price = 499
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Name = "iWatch SE GPS 40mm Silver Aluminium Case with White Sport Band",
                            Photo = "/img/iwatchwhite6.jpg",
                            Price = 399
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Name = "iWatch SE GPS 40mm Silver Aluminium Case with White Sport Band",
                            Photo = "/img/iwatchblack6.jpg",
                            Price = 449
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            Name = "iPad 10.2\" Wi-Fi 32GB Space Gray 2020",
                            Photo = "/img/ipad10_2_gray.jpg",
                            Price = 449
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            Name = "iPad Air 10.9\" Wi-Fi 64GB Space Gray",
                            Photo = "/img/ipad_air_gray_10_9.jpg",
                            Price = 799
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 4,
                            Name = "iPad Pro 11\" M1 Wi-Fi + Cellular 128GB Space Gray",
                            Photo = "/img/ipad_pro_11_gray.jpg",
                            Price = 1499
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 4,
                            Name = "iPad Air 10.9\" Wi-Fi + Cellular 64GB Sky Blue",
                            Photo = "/img/ipad_air_10_9_blue.jpg",
                            Price = 1199
                        });
                });

            modelBuilder.Entity("asp_net_shop.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Client"
                        });
                });

            modelBuilder.Entity("asp_net_shop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.com",
                            FullName = "Admin",
                            Password = "5gT7IHLChtH7Y3jFzedMoMmfO6HZ9M71iWkCDvvCOC4=",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "max@dm.com",
                            FullName = "Max Dmitriev",
                            Password = "5gT7IHLChtH7Y3jFzedMoMmfO6HZ9M71iWkCDvvCOC4=",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("asp_net_shop.Models.Cart", b =>
                {
                    b.HasOne("asp_net_shop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asp_net_shop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("asp_net_shop.Models.Product", b =>
                {
                    b.HasOne("asp_net_shop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("asp_net_shop.Models.User", b =>
                {
                    b.HasOne("asp_net_shop.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("asp_net_shop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("asp_net_shop.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}