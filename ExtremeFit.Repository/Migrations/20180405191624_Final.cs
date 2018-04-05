using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExtremeFit.Repository.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_UnidadesSesi_UnidadeId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosUnidadesFavoritas_UnidadesSesi_UnidadeId",
                table: "FuncionariosUnidadesFavoritas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisas_Empresas_EmpresaId",
                table: "Pesquisas");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Pesquisas",
                newName: "EmpresaDomainId");

            migrationBuilder.RenameIndex(
                name: "IX_Pesquisas_EmpresaId",
                table: "Pesquisas",
                newName: "IX_Pesquisas_EmpresaDomainId");

            migrationBuilder.RenameColumn(
                name: "NomePermissao",
                table: "Permissoes",
                newName: "Permissao");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Perguntas",
                newName: "Pergunta");

            migrationBuilder.RenameColumn(
                name: "UnidadeId",
                table: "FuncionariosUnidadesFavoritas",
                newName: "UnidadeSesiId");

            migrationBuilder.RenameIndex(
                name: "IX_FuncionariosUnidadesFavoritas_UnidadeId",
                table: "FuncionariosUnidadesFavoritas",
                newName: "IX_FuncionariosUnidadesFavoritas_UnidadeSesiId");

            migrationBuilder.RenameColumn(
                name: "UnidadeId",
                table: "Eventos",
                newName: "UnidadeFavoritaId");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_UnidadeId",
                table: "Eventos",
                newName: "IX_Eventos_UnidadeFavoritaId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Alternativas",
                newName: "Resposta");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Dicas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_UnidadesSesi_UnidadeFavoritaId",
                table: "Eventos",
                column: "UnidadeFavoritaId",
                principalTable: "UnidadesSesi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosUnidadesFavoritas_UnidadesSesi_UnidadeSesiId",
                table: "FuncionariosUnidadesFavoritas",
                column: "UnidadeSesiId",
                principalTable: "UnidadesSesi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisas_Empresas_EmpresaDomainId",
                table: "Pesquisas",
                column: "EmpresaDomainId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_UnidadesSesi_UnidadeFavoritaId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosUnidadesFavoritas_UnidadesSesi_UnidadeSesiId",
                table: "FuncionariosUnidadesFavoritas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisas_Empresas_EmpresaDomainId",
                table: "Pesquisas");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Dicas");

            migrationBuilder.RenameColumn(
                name: "EmpresaDomainId",
                table: "Pesquisas",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pesquisas_EmpresaDomainId",
                table: "Pesquisas",
                newName: "IX_Pesquisas_EmpresaId");

            migrationBuilder.RenameColumn(
                name: "Permissao",
                table: "Permissoes",
                newName: "NomePermissao");

            migrationBuilder.RenameColumn(
                name: "Pergunta",
                table: "Perguntas",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "UnidadeSesiId",
                table: "FuncionariosUnidadesFavoritas",
                newName: "UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_FuncionariosUnidadesFavoritas_UnidadeSesiId",
                table: "FuncionariosUnidadesFavoritas",
                newName: "IX_FuncionariosUnidadesFavoritas_UnidadeId");

            migrationBuilder.RenameColumn(
                name: "UnidadeFavoritaId",
                table: "Eventos",
                newName: "UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_UnidadeFavoritaId",
                table: "Eventos",
                newName: "IX_Eventos_UnidadeId");

            migrationBuilder.RenameColumn(
                name: "Resposta",
                table: "Alternativas",
                newName: "Descricao");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_UnidadesSesi_UnidadeId",
                table: "Eventos",
                column: "UnidadeId",
                principalTable: "UnidadesSesi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosUnidadesFavoritas_UnidadesSesi_UnidadeId",
                table: "FuncionariosUnidadesFavoritas",
                column: "UnidadeId",
                principalTable: "UnidadesSesi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisas_Empresas_EmpresaId",
                table: "Pesquisas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
