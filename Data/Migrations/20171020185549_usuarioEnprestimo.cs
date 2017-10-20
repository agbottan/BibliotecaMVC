using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BibliotecaMVC.Data.Migrations
{
    public partial class usuarioEnprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Emprestimo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ApplicationUserId",
                table: "Emprestimo",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_AspNetUsers_ApplicationUserId",
                table: "Emprestimo",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_AspNetUsers_ApplicationUserId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_ApplicationUserId",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Emprestimo");
        }
    }
}
