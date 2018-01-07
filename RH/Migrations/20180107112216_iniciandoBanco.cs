using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RH.Migrations
{
    public partial class iniciandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnologias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoProcesso",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(nullable: false),
                    ProcessoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoProcesso", x => new { x.CandidatoId, x.ProcessoId });
                    table.ForeignKey(
                        name: "FK_CandidatoProcesso_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoProcesso_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoTecnologia",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(nullable: false),
                    TecnologiaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoTecnologia", x => new { x.CandidatoId, x.TecnologiaId });
                    table.ForeignKey(
                        name: "FK_CandidatoTecnologia_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoTecnologia_Tecnologias_TecnologiaId",
                        column: x => x.TecnologiaId,
                        principalTable: "Tecnologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessoTecnologia",
                columns: table => new
                {
                    ProcessoId = table.Column<int>(nullable: false),
                    TecnologiaId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessoTecnologia", x => new { x.ProcessoId, x.TecnologiaId });
                    table.ForeignKey(
                        name: "FK_ProcessoTecnologia_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessoTecnologia_Tecnologias_TecnologiaId",
                        column: x => x.TecnologiaId,
                        principalTable: "Tecnologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoProcesso_ProcessoId",
                table: "CandidatoProcesso",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoTecnologia_TecnologiaId",
                table: "CandidatoTecnologia",
                column: "TecnologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoTecnologia_TecnologiaId",
                table: "ProcessoTecnologia",
                column: "TecnologiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoProcesso");

            migrationBuilder.DropTable(
                name: "CandidatoTecnologia");

            migrationBuilder.DropTable(
                name: "ProcessoTecnologia");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Tecnologias");
        }
    }
}
