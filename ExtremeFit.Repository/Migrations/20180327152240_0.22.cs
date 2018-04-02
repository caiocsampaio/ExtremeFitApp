using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtremeFit.Repository.Migrations
{
    public partial class _022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeFantasia = table.Column<string>(maxLength: 40, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 40, nullable: false),
                    CNAE = table.Column<string>(maxLength: 9, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntensidadeDores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Intensidade = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntensidadeDores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalDores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocalDor = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalDores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Setor = table.Column<string>(maxLength: 30, nullable: false),
                    Funcao = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosFuncionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosFuncionarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    IntensidadeDorId = table.Column<int>(nullable: false),
                    LocalDorId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Setor = table.Column<string>(maxLength: 30, nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatorios_IntensidadeDores_IntensidadeDorId",
                        column: x => x.IntensidadeDorId,
                        principalTable: "IntensidadeDores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatorios_LocalDores_LocalDorId",
                        column: x => x.LocalDorId,
                        principalTable: "LocalDores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternativas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    PerguntaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternativas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesquisas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativaId = table.Column<int>(nullable: false),
                    Pergunta = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(maxLength: 30, nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesquisas_Alternativas_AlternativaId",
                        column: x => x.AlternativaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pesquisas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_PerguntaId",
                table: "Alternativas",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosFuncionarios_EmpresaId",
                table: "DadosFuncionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisas_AlternativaId",
                table: "Pesquisas",
                column: "AlternativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisas_EmpresaId",
                table: "Pesquisas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_EmpresaId",
                table: "Relatorios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_IntensidadeDorId",
                table: "Relatorios",
                column: "IntensidadeDorId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_LocalDorId",
                table: "Relatorios",
                column: "LocalDorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosFuncionarios");

            migrationBuilder.DropTable(
                name: "Pesquisas");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Alternativas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "IntensidadeDores");

            migrationBuilder.DropTable(
                name: "LocalDores");

            migrationBuilder.DropTable(
                name: "Perguntas");
        }
    }
}
