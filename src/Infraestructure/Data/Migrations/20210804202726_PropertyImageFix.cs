using Microsoft.EntityFrameworkCore.Migrations;

namespace Weelo.Infraestructure.Data.Migrations
{
    public partial class PropertyImageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_Properties_Id",
                table: "PropertyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTraces_Properties_Id",
                table: "PropertyTraces");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTraces_PropertyId",
                table: "PropertyTraces",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
