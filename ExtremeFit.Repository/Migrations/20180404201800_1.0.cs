using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExtremeFit.Repository.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Esporte = table.Column<string>(maxLength: 20, nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNAE = table.Column<string>(maxLength: 9, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 40, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 40, nullable: false)
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
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePermissao = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesSesi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(maxLength: 30, nullable: false),
                    NomeUnidade = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesSesi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Digital = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Rfid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Funcao = table.Column<string>(maxLength: 30, nullable: false),
                    Setor = table.Column<string>(maxLength: 30, nullable: false)
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
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    IntensidadeDorId = table.Column<int>(nullable: false),
                    LocalDorId = table.Column<int>(nullable: false),
                    Setor = table.Column<string>(maxLength: 30, nullable: false)
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
                name: "Dicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Validacao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dicas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especialistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Especialidade = table.Column<string>(maxLength: 30, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialistas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    UnidadeId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_UnidadesSesi_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "UnidadesSesi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Altura = table.Column<double>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 15, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosPermissoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PermissaoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPermissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosPermissoes_Permissoes_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosPermissoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
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
                    Data = table.Column<DateTime>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Pergunta = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(maxLength: 30, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FuncionariosUnidadesFavoritas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FuncionarioId = table.Column<int>(nullable: false),
                    UnidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosUnidadesFavoritas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionariosUnidadesFavoritas_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosUnidadesFavoritas_UnidadesSesi_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "UnidadesSesi",
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
                name: "IX_Dicas_UsuarioId",
                table: "Dicas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialistas_UsuarioId",
                table: "Especialistas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UnidadeId",
                table: "Eventos",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UsuarioId",
                table: "Funcionarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosUnidadesFavoritas_FuncionarioId",
                table: "FuncionariosUnidadesFavoritas",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosUnidadesFavoritas_UnidadeId",
                table: "FuncionariosUnidadesFavoritas",
                column: "UnidadeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPermissoes_PermissaoId",
                table: "UsuariosPermissoes",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPermissoes_UsuarioId",
                table: "UsuariosPermissoes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "DadosFuncionarios");

            migrationBuilder.DropTable(
                name: "Dicas");

            migrationBuilder.DropTable(
                name: "Especialistas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "FuncionariosUnidadesFavoritas");

            migrationBuilder.DropTable(
                name: "Pesquisas");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "UsuariosPermissoes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "UnidadesSesi");

            migrationBuilder.DropTable(
                name: "Alternativas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "IntensidadeDores");

            migrationBuilder.DropTable(
                name: "LocalDores");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perguntas");
        }
    }
}
