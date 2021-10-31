﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services;

namespace services.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211031175054_db_inits")]
    partial class db_inits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Services.Models.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocumentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DocumentType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            DocumentId = new Guid("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 346, DateTimeKind.Local).AddTicks(8120),
                            DocumentName = "Document A",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8390),
                            DocumentName = "Document B",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8430),
                            DocumentName = "Document C",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("ae630703-cbd1-471d-907f-52b757b7eb0e"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8440),
                            DocumentName = "Document D",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8450),
                            DocumentName = "Document E",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("8ed5b22d-2610-4ca4-bba7-91183cc66511"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8450),
                            DocumentName = "Document F",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("876b6f77-dbea-452e-8638-d04000bd44b1"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8460),
                            DocumentName = "Document G",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("33b6ffc5-b4e1-4187-95cd-189d33857246"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8470),
                            DocumentName = "Document H",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("b6e27851-c365-4287-9c58-dea7ee86ee97"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8470),
                            DocumentName = "Document I",
                            DocumentType = "Promotion"
                        },
                        new
                        {
                            DocumentId = new Guid("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8480),
                            DocumentName = "Document K",
                            DocumentType = "Promotion"
                        });
                });

            modelBuilder.Entity("Services.Models.DocumentKeyword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("KeywordId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("KeywordId");

                    b.ToTable("DocumentKeywords");
                });

            modelBuilder.Entity("Services.Models.DocumentProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Product")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Supplier")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentProperties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4659156e-38d0-49b1-b641-cbe266ff7a2a"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(3060),
                            DocumentId = new Guid("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"),
                            Product = "Laptop",
                            Supplier = "Supplier A"
                        },
                        new
                        {
                            Id = new Guid("a26e92ea-0298-4223-82e2-56f947df0359"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4430),
                            DocumentId = new Guid("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"),
                            Product = "Monitor",
                            Supplier = "Supplier A"
                        },
                        new
                        {
                            Id = new Guid("a764fe17-34e0-4069-ba97-10e3e977a564"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4470),
                            DocumentId = new Guid("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"),
                            Product = "Laptop",
                            Supplier = "Supplier B"
                        },
                        new
                        {
                            Id = new Guid("e9774ae8-0628-4b00-ab3f-89513c9fba27"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4480),
                            DocumentId = new Guid("ae630703-cbd1-471d-907f-52b757b7eb0e"),
                            Product = "Monitor",
                            Supplier = "Supplier B"
                        },
                        new
                        {
                            Id = new Guid("a680fe69-d674-4fab-8c1b-db7c9690b147"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4490),
                            DocumentId = new Guid("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"),
                            Product = "Tablet",
                            Supplier = "Supplier A"
                        },
                        new
                        {
                            Id = new Guid("24e6d736-95f9-48d9-b803-012a6d8a3a7d"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4500),
                            DocumentId = new Guid("8ed5b22d-2610-4ca4-bba7-91183cc66511"),
                            Product = "Laptop",
                            Supplier = "Supplier C"
                        },
                        new
                        {
                            Id = new Guid("4779e52a-88e5-404a-807b-327e2ed1cabb"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4510),
                            DocumentId = new Guid("876b6f77-dbea-452e-8638-d04000bd44b1"),
                            Product = "Laptop",
                            Supplier = "Supplier A"
                        },
                        new
                        {
                            Id = new Guid("32a1fea7-140b-4713-8f77-11e675bafdf5"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4520),
                            DocumentId = new Guid("33b6ffc5-b4e1-4187-95cd-189d33857246"),
                            Product = "Laptop",
                            Supplier = "Supplier B"
                        },
                        new
                        {
                            Id = new Guid("f1ab8560-9035-44f7-a5bf-ddf70e2f4928"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4530),
                            DocumentId = new Guid("b6e27851-c365-4287-9c58-dea7ee86ee97"),
                            Product = "Laptop",
                            Supplier = "Supplier A"
                        },
                        new
                        {
                            Id = new Guid("a4b8455c-d510-462e-8b90-c50a73b6f6d8"),
                            CreatedBy = new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"),
                            CreatedOn = new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4540),
                            DocumentId = new Guid("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"),
                            Product = "Laptop",
                            Supplier = "Supplier C"
                        });
                });

            modelBuilder.Entity("Services.Models.Keyword", b =>
                {
                    b.Property<Guid>("KeywordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("KeywordId");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("Services.Models.Role", b =>
                {
                    b.Property<string>("RoleCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("RoleCode");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Services.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("EmailConfirmation")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Services.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleCode")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleCode");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Services.Models.DocumentKeyword", b =>
                {
                    b.HasOne("Services.Models.Document", "Document")
                        .WithMany("DocumentKeywords")
                        .HasForeignKey("DocumentId");

                    b.HasOne("Services.Models.Keyword", "Keyword")
                        .WithMany("DocumentKeywords")
                        .HasForeignKey("KeywordId");
                });

            modelBuilder.Entity("Services.Models.DocumentProperty", b =>
                {
                    b.HasOne("Services.Models.Document", "Document")
                        .WithMany("DocumentProperties")
                        .HasForeignKey("DocumentId");
                });

            modelBuilder.Entity("Services.Models.UserRole", b =>
                {
                    b.HasOne("Services.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleCode");

                    b.HasOne("Services.Models.User", "UserDetail")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
