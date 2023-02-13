﻿// <auto-generated />
using System;
using ECommerce_Additional.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce_Additional.Migrations
{
    [DbContext(typeof(UserCartContext))]
    [Migration("20230210090858_test1")]
    partial class test1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce_Additional.Entities.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0483cc0e-85b5-487d-a540-8096ea2a1891"),
                            ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            quantity = 2
                        });
                });

            modelBuilder.Entity("ECommerce_Additional.Entities.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                            PaymentMethod = "UPI",
                            PaymentTime = new DateTime(2023, 2, 10, 14, 38, 58, 679, DateTimeKind.Local).AddTicks(8392),
                            Price = 5000f,
                            ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                            Quantity = 1,
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be")
                        });
                });

            modelBuilder.Entity("ECommerce_Additional.Entities.Models.WishList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WishLists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("698f8b7b-65d2-4425-b724-46c076943f17"),
                            Name = "MyMobileCollection",
                            ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
