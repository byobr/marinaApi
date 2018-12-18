﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApiMarina.Models;

namespace webApiMarina.Migrations
{
    [DbContext(typeof(Banco))]
    [Migration("20181218011545_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webApiMarina.Models.Domain.Alimentos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConsultaAlimentosid");

                    b.Property<int>("calorias");

                    b.Property<int>("categoriaid");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("id");

                    b.HasIndex("ConsultaAlimentosid");

                    b.HasIndex("categoriaid");

                    b.ToTable("alimentos");
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.CategoriaAlimentos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomeCategoria")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("categoriaAlimentos");
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.Clientes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataNascimento");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("endereco")
                        .IsRequired();

                    b.Property<string>("nome")
                        .IsRequired();

                    b.Property<string>("telefoneCelular")
                        .IsRequired();

                    b.Property<string>("telefoneComercial");

                    b.Property<string>("telefoneResidencial");

                    b.HasKey("id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.ConsultaAlimentos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("consultaid");

                    b.HasKey("id");

                    b.HasIndex("consultaid");

                    b.ToTable("consultaAlimentos");
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.Consultas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("clienteid");

                    b.Property<DateTime>("dataHora");

                    b.Property<int>("metaCalorias");

                    b.Property<double>("peso");

                    b.Property<double>("porcentualGordura");

                    b.Property<string>("restricoesAlimentares");

                    b.Property<string>("sensacaoFisica")
                        .HasMaxLength(150);

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.ToTable("consultas");
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.Alimentos", b =>
                {
                    b.HasOne("webApiMarina.Models.Domain.ConsultaAlimentos")
                        .WithMany("alimentos")
                        .HasForeignKey("ConsultaAlimentosid");

                    b.HasOne("webApiMarina.Models.Domain.CategoriaAlimentos", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.ConsultaAlimentos", b =>
                {
                    b.HasOne("webApiMarina.Models.Domain.Consultas", "consulta")
                        .WithMany("consultaAlimentos")
                        .HasForeignKey("consultaid");
                });

            modelBuilder.Entity("webApiMarina.Models.Domain.Consultas", b =>
                {
                    b.HasOne("webApiMarina.Models.Domain.Clientes", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid");
                });
#pragma warning restore 612, 618
        }
    }
}
