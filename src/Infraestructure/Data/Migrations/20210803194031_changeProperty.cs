using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weelo.Infraestructure.Data.Migrations
{
    public partial class changeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_Properties_PropertyId",
                table: "PropertyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTraces_Properties_PropertyId",
                table: "PropertyTraces");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTraces_PropertyId",
                table: "PropertyTraces");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Users",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "PropertyTraces",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "PropertyImages",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Properties",
                newName: "PropertyTraceId");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Owners",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "PropertyImages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "PropertyImages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Calification",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyImageId",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImages_Properties_Id",
                table: "PropertyImages",
                column: "Id",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTraces_Properties_Id",
                table: "PropertyTraces",
                column: "Id",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_Properties_Id",
                table: "PropertyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTraces_Properties_Id",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "Calification",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyImageId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Users",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "PropertyTraces",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "PropertyImages",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "PropertyTraceId",
                table: "Properties",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Owners",
                newName: "CreateOn");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTraces_PropertyId",
                table: "PropertyTraces",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImages_Properties_PropertyId",
                table: "PropertyImages",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTraces_Properties_PropertyId",
                table: "PropertyTraces",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
