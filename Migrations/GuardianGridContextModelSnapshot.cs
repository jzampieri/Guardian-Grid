﻿// <auto-generated />
using System;
using GuardianGrid.AdminPanel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuardianGrid.AdminPanel.Migrations
{
    [DbContext(typeof(GuardianGridContext))]
    partial class GuardianGridContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("GuardianGrid.AdminPanel.Models.Alerta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("RegiaoAfetada")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alertas");
                });

            modelBuilder.Entity("GuardianGrid.AdminPanel.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataOcorrencia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ZonaCritica")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
