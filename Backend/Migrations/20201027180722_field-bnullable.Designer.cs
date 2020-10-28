﻿// <auto-generated />
using System;
using FabiApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FabiApi.Migrations
{
    [DbContext(typeof(pgConnection))]
    [Migration("20201027180722_field-bnullable")]
    partial class fieldbnullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FabiApi.Entities.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("FabiApi.Entities.DocumentoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<double>("Costo")
                        .HasColumnType("double precision");

                    b.Property<int>("ProductoId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoTransaccionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("TipoTransaccionId");

                    b.ToTable("DocumentoDetalles");
                });

            modelBuilder.Entity("FabiApi.Entities.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Abierto")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaCerrado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("FabiApi.Entities.LoteDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<int>("CantidadUsada")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("LoteDetalles");
                });

            modelBuilder.Entity("FabiApi.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("FabiApi.Entities.ProductoAuxiliar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<int>("DocumentoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LoteId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductoId")
                        .HasColumnType("integer");

                    b.Property<int>("tipoTransaccionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("LoteId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("tipoTransaccionId");

                    b.ToTable("ProductoAuxiliar");
                });

            modelBuilder.Entity("FabiApi.Entities.TipoTransaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoTransaccions");
                });

            modelBuilder.Entity("FabiApi.Entities.DocumentoDetalle", b =>
                {
                    b.HasOne("FabiApi.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FabiApi.Entities.TipoTransaccion", "TipoTransaccion")
                        .WithMany()
                        .HasForeignKey("TipoTransaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FabiApi.Entities.LoteDetalle", b =>
                {
                    b.HasOne("FabiApi.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FabiApi.Entities.ProductoAuxiliar", b =>
                {
                    b.HasOne("FabiApi.Entities.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FabiApi.Entities.Lote", "Lote")
                        .WithMany()
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FabiApi.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FabiApi.Entities.TipoTransaccion", "TipoTransaccion")
                        .WithMany()
                        .HasForeignKey("tipoTransaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
