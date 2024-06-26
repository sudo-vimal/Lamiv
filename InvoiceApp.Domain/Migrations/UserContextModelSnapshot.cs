﻿// <auto-generated />
using System;
using InvoiceApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceApp.Domain.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("InvoiceApp.Domain.Entity.EnumEntities.UserTypeEnum", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserTypeEnum");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "None"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Master"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("InvoiceApp.Domain.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserTypeFK")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("UserTypeFK");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InvoiceApp.Domain.Entity.UserEntity", b =>
                {
                    b.HasOne("InvoiceApp.Domain.Entity.EnumEntities.UserTypeEnum", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("InvoiceApp.Domain.Entity.EnumEntities.UserTypeEnum", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
