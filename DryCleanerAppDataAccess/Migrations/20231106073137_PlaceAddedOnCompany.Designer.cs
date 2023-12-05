﻿// <auto-generated />
using System;
using DryCleanerAppDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DryCleanerAppDataAccess.Migrations
{
    [DbContext(typeof(DryCleanerContext))]
    [Migration("20231106073137_PlaceAddedOnCompany")]
    partial class PlaceAddedOnCompany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyCity")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyCountry")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyPhone")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyState")
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("CreatedOn")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LandMark")
                        .HasColumnType("longtext");

                    b.Property<string>("Place")
                        .HasColumnType("longtext");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedOn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("companyEntities");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.LoginLogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedOn")
                        .HasColumnType("int");

                    b.Property<string>("UserAgent")
                        .HasColumnType("longtext");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserDataId");

                    b.ToTable("loginLog");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.UserAddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressFor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("CreatedOn")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LandMark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedOn")
                        .HasColumnType("int");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("usersAddress");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("CreatedOn")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedOn")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.LoginLogEntity", b =>
                {
                    b.HasOne("DryCleanerAppDataAccess.Entities.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DryCleanerAppDataAccess.Entities.UserEntity", "UserData")
                        .WithMany()
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.UserAddressEntity", b =>
                {
                    b.HasOne("DryCleanerAppDataAccess.Entities.UserEntity", null)
                        .WithMany("UserAddress")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.UserEntity", b =>
                {
                    b.HasOne("DryCleanerAppDataAccess.Entities.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DryCleanerAppDataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("UserAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
