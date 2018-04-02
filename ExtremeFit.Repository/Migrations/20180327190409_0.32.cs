using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtremeFit.Repository.Migrations
{
    public partial class _032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Eventos_UnidadeId",
                table: "Eventos");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UnidadeId",
                table: "Eventos",
                column: "UnidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Eventos_UnidadeId",
                table: "Eventos");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UnidadeId",
                table: "Eventos",
                column: "UnidadeId",
                unique: true);
        }
    }
}
