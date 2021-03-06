// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asp_net_shop.Models;

namespace asp_net_shop.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210711130255_InitialCreate")]
    partial class InitialCreate
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

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("asp_net_shop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apple iPhone"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Apple iMac"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Apple Watch"
                        });
                });

            modelBuilder.Entity("asp_net_shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

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

                    b.HasIndex("CartId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb Black",
                            Photo = "iphone11_128gb_black.jpeg",
                            Price = 920
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb White",
                            Photo = "iphone11_128gb_white.jpeg",
                            Price = 940
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "iPhone 11 128gb Green",
                            Photo = "iphone11_128gb_green.jpeg",
                            Price = 900
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "iMax 27\"",
                            Price = 1899
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Name = "Apple Watch 5",
                            Price = 499
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

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

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

            modelBuilder.Entity("asp_net_shop.Models.Product", b =>
                {
                    b.HasOne("asp_net_shop.Models.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("asp_net_shop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("asp_net_shop.Models.User", b =>
                {
                    b.HasOne("asp_net_shop.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("asp_net_shop.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("asp_net_shop.Models.Cart", b =>
                {
                    b.Navigation("Products");
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
