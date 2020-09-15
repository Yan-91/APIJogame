﻿// <auto-generated />
using System;
using APIJogame.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIJogame.Migrations
{
    [DbContext(typeof(JogoContext))]
    partial class JogoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIJogame.Domains.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jogadors");
                });

            modelBuilder.Entity("APIJogame.Domains.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLanç")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrição")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("APIJogame.Domains.JogoJogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdJogador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdJogo")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdJogador");

                    b.HasIndex("IdJogo");

                    b.ToTable("JogoJogadores");
                });

            modelBuilder.Entity("APIJogame.Domains.JogoJogador", b =>
                {
                    b.HasOne("APIJogame.Domains.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("IdJogador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIJogame.Domains.Jogo", "Jogo")
                        .WithMany()
                        .HasForeignKey("IdJogo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
