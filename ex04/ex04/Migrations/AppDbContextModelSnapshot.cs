﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ex04.Data;

#nullable disable

namespace ex04.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ex04.Models.Equipo", b =>
                {
                    b.Property<string>("NumSerie")
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<int>("FacultadCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("NumSerie");

                    b.HasIndex("FacultadCodigo");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("ex04.Models.Facultad", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Codigo");

                    b.ToTable("Facultades");
                });

            modelBuilder.Entity("ex04.Models.Investigador", b =>
                {
                    b.Property<string>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<int>("FacultadCodigo")
                        .HasColumnType("int");

                    b.Property<string>("NomApels")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("DNI");

                    b.HasIndex("FacultadCodigo");

                    b.ToTable("Investigadores");
                });

            modelBuilder.Entity("ex04.Models.Reserva", b =>
                {
                    b.Property<string>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("NumSerie")
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<DateTime>("Comienzo")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DNI", "NumSerie");

                    b.HasIndex("NumSerie");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ex04.Models.Equipo", b =>
                {
                    b.HasOne("ex04.Models.Facultad", "Facultad")
                        .WithMany("Equipos")
                        .HasForeignKey("FacultadCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facultad");
                });

            modelBuilder.Entity("ex04.Models.Investigador", b =>
                {
                    b.HasOne("ex04.Models.Facultad", "Facultad")
                        .WithMany("Investigadores")
                        .HasForeignKey("FacultadCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facultad");
                });

            modelBuilder.Entity("ex04.Models.Reserva", b =>
                {
                    b.HasOne("ex04.Models.Investigador", "Investigador")
                        .WithMany("Reservas")
                        .HasForeignKey("DNI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ex04.Models.Equipo", "Equipo")
                        .WithMany("Reservas")
                        .HasForeignKey("NumSerie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");

                    b.Navigation("Investigador");
                });

            modelBuilder.Entity("ex04.Models.Equipo", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ex04.Models.Facultad", b =>
                {
                    b.Navigation("Equipos");

                    b.Navigation("Investigadores");
                });

            modelBuilder.Entity("ex04.Models.Investigador", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
