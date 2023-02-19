using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Board.Data.Migrations
{
    public partial class NewFileMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_Publications_PublicationId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FileModels");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "FileModels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DataFiles",
                table: "FileModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FileModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "FileModels",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_Publications_PublicationId",
                table: "FileModels",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_Publications_PublicationId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "DataFiles",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "FileModels");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "FileModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "FileModels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_Publications_PublicationId",
                table: "FileModels",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
