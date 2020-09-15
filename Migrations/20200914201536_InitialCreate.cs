﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIJogame.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogadors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descrição = table.Column<string>(nullable: true),
                    DataLanç = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogoJogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdJogo = table.Column<Guid>(nullable: false),
                    IdJogador = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoJogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogoJogadores_Jogadors_IdJogador",
                        column: x => x.IdJogador,
                        principalTable: "Jogadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoJogadores_Jogos_IdJogo",
                        column: x => x.IdJogo,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogoJogadores_IdJogador",
                table: "JogoJogadores",
                column: "IdJogador");

            migrationBuilder.CreateIndex(
                name: "IX_JogoJogadores_IdJogo",
                table: "JogoJogadores",
                column: "IdJogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogoJogadores");

            migrationBuilder.DropTable(
                name: "Jogadors");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
