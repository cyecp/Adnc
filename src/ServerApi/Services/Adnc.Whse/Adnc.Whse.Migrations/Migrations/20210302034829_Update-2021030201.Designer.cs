﻿// <auto-generated />
using System;
using Adnc.Infra.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adnc.Whse.Migrations.Migrations
{
    [DbContext(typeof(AdncDbContext))]
    [Migration("20210302034829_Update-2021030201")]
    partial class Update2021030201
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Adnc.Whse.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Describe")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("varchar(4) CHARACTER SET utf8mb4")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Adnc.Whse.Domain.Entities.Warehouse", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("BlockedQty")
                        .HasColumnType("int");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.HasKey("Id");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("Adnc.Whse.Domain.Entities.Product", b =>
                {
                    b.OwnsOne("Adnc.Whse.Domain.Entities.ProductStatus", "Status", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("ChangesReason")
                                .HasColumnName("StatusChangesReason")
                                .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                                .HasMaxLength(32);

                            b1.Property<int>("Code")
                                .HasColumnName("StatusCode")
                                .HasColumnType("int");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });
                });

            modelBuilder.Entity("Adnc.Whse.Domain.Entities.Warehouse", b =>
                {
                    b.OwnsOne("Adnc.Whse.Domain.Entities.WarehousePosition", "Position", b1 =>
                        {
                            b1.Property<long>("WarehouseId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnName("PositionCode")
                                .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                                .HasMaxLength(32);

                            b1.Property<string>("Description")
                                .HasColumnName("PositionDescription")
                                .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                                .HasMaxLength(64);

                            b1.HasKey("WarehouseId");

                            b1.ToTable("Warehouse");

                            b1.WithOwner()
                                .HasForeignKey("WarehouseId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
