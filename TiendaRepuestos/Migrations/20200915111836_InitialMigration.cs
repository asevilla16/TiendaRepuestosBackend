using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaRepuestos.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_repuestos_categorias_categoriaid",
                table: "repuestos");

            migrationBuilder.DropIndex(
                name: "IX_repuestos_categoriaid",
                table: "repuestos");

            migrationBuilder.DropColumn(
                name: "categoriaid",
                table: "repuestos");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "vehiculos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    idVenta = table.Column<int>(nullable: false),
                    idRepuesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_repuestos_idRepuesto",
                        column: x => x.idRepuesto,
                        principalTable: "repuestos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    idRepuesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Inventario_repuestos_idRepuesto",
                        column: x => x.idRepuesto,
                        principalTable: "repuestos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    idCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Venta_clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_repuestos_idCategoria",
                table: "repuestos",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_idRepuesto",
                table: "DetalleVenta",
                column: "idRepuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_idRepuesto",
                table: "Inventario",
                column: "idRepuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_idCliente",
                table: "Venta",
                column: "idCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_repuestos_categorias_idCategoria",
                table: "repuestos",
                column: "idCategoria",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_repuestos_categorias_idCategoria",
                table: "repuestos");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_repuestos_idCategoria",
                table: "repuestos");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "vehiculos",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AddColumn<int>(
                name: "categoriaid",
                table: "repuestos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_repuestos_categoriaid",
                table: "repuestos",
                column: "categoriaid");

            migrationBuilder.AddForeignKey(
                name: "FK_repuestos_categorias_categoriaid",
                table: "repuestos",
                column: "categoriaid",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
