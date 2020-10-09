using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaRepuestos.Migrations
{
    public partial class AddedVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_idVenta",
                table: "DetalleVenta",
                column: "idVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Venta_idVenta",
                table: "DetalleVenta",
                column: "idVenta",
                principalTable: "Venta",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Venta_idVenta",
                table: "DetalleVenta");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVenta_idVenta",
                table: "DetalleVenta");
        }
    }
}
