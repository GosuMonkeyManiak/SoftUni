﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetStore.Data;

namespace PetStore.Data.Migrations
{
    [DbContext(typeof(PetStoreContext))]
    [Migration("20211128205531_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PetStore.Models.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("PetStore.Models.CustomerServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerServiceTypes");
                });

            modelBuilder.Entity("PetStore.Models.Decoration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<int>("DecorationDistributorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DecorationDistributorId");

                    b.ToTable("Decorations");
                });

            modelBuilder.Entity("PetStore.Models.DecorationDistributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DecorationDistributors");
                });

            modelBuilder.Entity("PetStore.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FoodDistributorId")
                        .HasColumnType("int");

                    b.Property<decimal>("KgHave")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceByKg")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodDistributorId");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("PetStore.Models.FoodDistributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("PriceByKg")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("FoodDistributors");
                });

            modelBuilder.Entity("PetStore.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("PetStore.Models.IncomeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CustomerPayOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerServiceTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerServiceTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("IncomeLogs");
                });

            modelBuilder.Entity("PetStore.Models.PaymentLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("PayOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("PaymentLogs");
                });

            modelBuilder.Entity("PetStore.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("PetStore.Models.Pet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("GenderId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetStore.Models.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("PetTypes");
                });

            modelBuilder.Entity("PetStore.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PetTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetTypeId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PetStore.Models.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("PetStore.Models.Toy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ToyDistributorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetTypeId");

                    b.HasIndex("ToyDistributorId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("PetStore.Models.ToyDistributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ToyDistributors");
                });

            modelBuilder.Entity("PetStore.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PetStore.Models.UserDecoration", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DecorationId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "DecorationId");

                    b.HasIndex("DecorationId");

                    b.ToTable("UsersDecorations");
                });

            modelBuilder.Entity("PetStore.Models.UserFood", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("UsersFoods");
                });

            modelBuilder.Entity("PetStore.Models.UserService", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("UsersServices");
                });

            modelBuilder.Entity("PetStore.Models.UserToy", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ToyId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ToyId");

                    b.HasIndex("ToyId");

                    b.ToTable("UsersToys");
                });

            modelBuilder.Entity("PetStore.Models.Breed", b =>
                {
                    b.HasOne("PetStore.Models.PetType", "PetType")
                        .WithMany("Breeds")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("PetStore.Models.Decoration", b =>
                {
                    b.HasOne("PetStore.Models.DecorationDistributor", "DecorationDistributor")
                        .WithMany("Decorations")
                        .HasForeignKey("DecorationDistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DecorationDistributor");
                });

            modelBuilder.Entity("PetStore.Models.Food", b =>
                {
                    b.HasOne("PetStore.Models.FoodDistributor", "FoodDistributor")
                        .WithMany("Foods")
                        .HasForeignKey("FoodDistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.PetType", "PetType")
                        .WithMany("Foods")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodDistributor");

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("PetStore.Models.IncomeLog", b =>
                {
                    b.HasOne("PetStore.Models.CustomerServiceType", "CustomerServiceType")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");

                    b.Navigation("CustomerServiceType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetStore.Models.PaymentLog", b =>
                {
                    b.HasOne("PetStore.Models.PaymentType", "PaymentType")
                        .WithMany("PaymentLogs")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("PetStore.Models.Pet", b =>
                {
                    b.HasOne("PetStore.Models.Breed", "Breed")
                        .WithMany("Pets")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.User", "Buyer")
                        .WithMany("Pets")
                        .HasForeignKey("BuyerId");

                    b.HasOne("PetStore.Models.Gender", "Gender")
                        .WithMany("Pets")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");

                    b.Navigation("Buyer");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("PetStore.Models.Service", b =>
                {
                    b.HasOne("PetStore.Models.PetType", "PetType")
                        .WithMany("Services")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("PetStore.Models.Toy", b =>
                {
                    b.HasOne("PetStore.Models.PetType", "PetType")
                        .WithMany("Toys")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.ToyDistributor", "ToyDistributor")
                        .WithMany("Toys")
                        .HasForeignKey("ToyDistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");

                    b.Navigation("ToyDistributor");
                });

            modelBuilder.Entity("PetStore.Models.UserDecoration", b =>
                {
                    b.HasOne("PetStore.Models.Decoration", "Decoration")
                        .WithMany("UsersDecorations")
                        .HasForeignKey("DecorationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.User", "User")
                        .WithMany("UsersDecorations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decoration");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetStore.Models.UserFood", b =>
                {
                    b.HasOne("PetStore.Models.Food", "Food")
                        .WithMany("UsersFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.User", "User")
                        .WithMany("UsersFoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetStore.Models.UserService", b =>
                {
                    b.HasOne("PetStore.Models.Service", "Service")
                        .WithMany("UsersServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.User", "User")
                        .WithMany("UsersServices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetStore.Models.UserToy", b =>
                {
                    b.HasOne("PetStore.Models.Toy", "Toy")
                        .WithMany("UsersToys")
                        .HasForeignKey("ToyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStore.Models.User", "User")
                        .WithMany("UsersToys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Toy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetStore.Models.Breed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetStore.Models.CustomerServiceType", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PetStore.Models.Decoration", b =>
                {
                    b.Navigation("UsersDecorations");
                });

            modelBuilder.Entity("PetStore.Models.DecorationDistributor", b =>
                {
                    b.Navigation("Decorations");
                });

            modelBuilder.Entity("PetStore.Models.Food", b =>
                {
                    b.Navigation("UsersFoods");
                });

            modelBuilder.Entity("PetStore.Models.FoodDistributor", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("PetStore.Models.Gender", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetStore.Models.PaymentType", b =>
                {
                    b.Navigation("PaymentLogs");
                });

            modelBuilder.Entity("PetStore.Models.PetType", b =>
                {
                    b.Navigation("Breeds");

                    b.Navigation("Foods");

                    b.Navigation("Services");

                    b.Navigation("Toys");
                });

            modelBuilder.Entity("PetStore.Models.Service", b =>
                {
                    b.Navigation("UsersServices");
                });

            modelBuilder.Entity("PetStore.Models.ServiceType", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("PetStore.Models.Toy", b =>
                {
                    b.Navigation("UsersToys");
                });

            modelBuilder.Entity("PetStore.Models.ToyDistributor", b =>
                {
                    b.Navigation("Toys");
                });

            modelBuilder.Entity("PetStore.Models.User", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("Transactions");

                    b.Navigation("UsersDecorations");

                    b.Navigation("UsersFoods");

                    b.Navigation("UsersServices");

                    b.Navigation("UsersToys");
                });
#pragma warning restore 612, 618
        }
    }
}
